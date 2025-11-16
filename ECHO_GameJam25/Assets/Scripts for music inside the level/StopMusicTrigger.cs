using UnityEngine;

public class StopMusicTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MusicManager.Instance.StopCurrentRoomMusic();
        }
    }
}
