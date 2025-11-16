using UnityEngine;
using TMPro;
using System.Collections;

public class ElevatorController2D : MonoBehaviour
{
    [Header("Elevator Movement")]
    public Transform elevator;
    public Transform pointA;
    public Transform pointB;
    public float moveSpeed = 3f;

    [Header("UI")]
    public TMP_Text messageText;    // Unique text for this elevator

    [Header("Audio")]
    public AudioClip elevatorClip;  // Unique audio for this elevator

    private bool isMoving = false;
    private AudioSource audioSource;

    private void Start()
    {
        // Elevator starts at pointA
        elevator.position = pointA.position;

        // Hide text initially
        if (messageText != null)
            messageText.gameObject.SetActive(false);

        // Create a unique AudioSource for this elevator
        audioSource = elevator.gameObject.AddComponent<AudioSource>();
        audioSource.clip = elevatorClip;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isMoving)
        {
            isMoving = true;

            // Start movement immediately
            StartCoroutine(MoveElevator());

            // Start delayed text + sound independently
            StartCoroutine(ShowMessageAndPlaySoundDelayed());
        }
    }

    private IEnumerator MoveElevator()
    {
        while (Vector3.Distance(elevator.position, pointB.position) > 0.01f)
        {
            elevator.position = Vector3.MoveTowards(
                elevator.position,
                pointB.position,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        // Ensure sound stops when elevator reaches the bottom
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();

        // Ensure text is hidden (in case elevator finished before 3 sec of text)
        if (messageText != null)
            messageText.gameObject.SetActive(false);
    }

    private IEnumerator ShowMessageAndPlaySoundDelayed()
    {
        // Wait 2 seconds before showing text and playing sound
        yield return new WaitForSeconds(2f);

        if (messageText != null)
            messageText.gameObject.SetActive(true);

        if (audioSource != null)
            audioSource.Play();

        // Keep both active for 3 seconds
        yield return new WaitForSeconds(3f);

        if (messageText != null)
            messageText.gameObject.SetActive(false);

        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop();
    }
}
