using System.Threading;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public DeathWall wallToActivate;

    public GameObject respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wallToActivate.ActivateWall();
            StartCoroutine(ScaleWall());
        }
    }

    private System.Collections.IEnumerator ScaleWall()
    {
        while (wallToActivate.transform.localScale.x < 1.25f && wallToActivate.transform.localScale.y < 22.25f) {
            if (GameObject.FindGameObjectWithTag("Player").transform.position == respawnPoint.transform.position)
                break;
            
            wallToActivate.transform.localScale = new Vector3(Mathf.Lerp(wallToActivate.transform.localScale.x, 0.75f, Time.time/800f), Mathf.Lerp(wallToActivate.transform.localScale.y, 22.25f, Time.time/800f), 1f);
            yield return null;
        }
    }
}
