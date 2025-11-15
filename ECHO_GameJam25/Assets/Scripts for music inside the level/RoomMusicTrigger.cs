using UnityEngine;

public class RoomMusicTrigger : MonoBehaviour
{
    public AudioSource roomMusic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MusicManager.Instance.PlayRoomMusic(roomMusic);
        }
    }
}
