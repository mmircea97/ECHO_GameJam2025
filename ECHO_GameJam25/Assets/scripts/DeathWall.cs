using UnityEngine;

public class DeathWall : MonoBehaviour
{
    [Header("Respawn Settings")]
    public Transform[] respawnPoints;

    [Header("Wall Settings")]
    public float speed = 5f;

    private Vector3 startPos;

    private Transform player;
    private Rigidbody2D playerRb;

    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    private Transform targetPoint;

    [Header("Activation")]
    public bool isActive = false;

    private void Start()
    {
        startPos = transform.position;
        targetPoint = pointB;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            playerRb = playerObj.GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        if (!isActive) return;
        if (pointA == null || pointB == null) return;

        // ░░ Mișcare DOAR pe axa X ░░
        float targetX = targetPoint.position.x;

        transform.position = new Vector3(
            Mathf.MoveTowards(transform.position.x, targetX, speed * Time.deltaTime),
            transform.position.y,
            transform.position.z
        );

        // Schimbă direcția când ajunge suficient de aproape
        if (Mathf.Abs(transform.position.x - targetX) < 0.05f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RespawnPlayer();
            ResetWall();
            isActive = false;
        }
    }

    private void RespawnPlayer()
    {
        if (respawnPoints.Length == 0) return;

        Transform nearest = respawnPoints[0];
        float minDist = Vector2.Distance(player.position, nearest.position);

        for (int i = 1; i < respawnPoints.Length; i++)
        {
            float dist = Vector2.Distance(player.position, respawnPoints[i].position);
            if (dist < minDist)
            {
                minDist = dist;
                nearest = respawnPoints[i];
            }
        }

        player.position = nearest.position;
        if (playerRb != null)
            playerRb.linearVelocity = Vector2.zero;
    }

    private void ResetWall()
    {
        transform.position = startPos;
        targetPoint = pointB;
    }

    public void ActivateWall()
    {
        isActive = true;
    }
}
