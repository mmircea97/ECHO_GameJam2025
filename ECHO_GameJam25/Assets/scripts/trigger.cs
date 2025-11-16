using UnityEngine;

public class trigger : MonoBehaviour
{
    public DeathWall wallToActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wallToActivate.ActivateWall();
            
        }
    }
}
