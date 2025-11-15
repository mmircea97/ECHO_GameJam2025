using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource currentRoomMusic;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayRoomMusic(AudioSource newRoomMusic)
    {
        if (currentRoomMusic == newRoomMusic) return;

        if (currentRoomMusic != null)
            currentRoomMusic.Stop();

        currentRoomMusic = newRoomMusic;
        currentRoomMusic.Play();
    }

    public IEnumerator SwitchToElevatorMusic(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (currentRoomMusic != null)
            currentRoomMusic.Stop();
    }
    public bool IsCurrentMusic(AudioSource music)
    {
        return currentRoomMusic == music;
    }
    public void StopCurrentRoomMusic()
    {
        if (currentRoomMusic != null)
            currentRoomMusic.Stop();
    }

}
