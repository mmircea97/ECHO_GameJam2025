using UnityEngine;

public class spike : MonoBehaviour
{
    [Header("Respawn Points")]
    public Transform[] respawnPoints; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Respawn(collision.gameObject);
        }
    }

    void Respawn(GameObject player)
    {
        if (respawnPoints.Length == 0)
        {
            Debug.LogWarning("Nu există puncte de respawn!");
            return;
        }

        
        Transform nearest = respawnPoints[0];
        float minDistance = Vector2.Distance(player.transform.position, nearest.position);

        for (int i = 1; i < respawnPoints.Length; i++)
        {
            float dist = Vector2.Distance(player.transform.position, respawnPoints[i].position);
            if (dist < minDistance)
            {
                minDistance = dist;
                nearest = respawnPoints[i];
            }
        }

        
        player.transform.position = nearest.position;

        
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
            rb.linearVelocity = Vector2.zero;
    }
}
