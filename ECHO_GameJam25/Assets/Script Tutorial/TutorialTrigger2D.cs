using UnityEngine;
using TMPro;
using System.Collections;

public class TutorialTrigger2D : MonoBehaviour
{
    [Header("Tutorial Settings")]
    public GameObject tutorialText;   // Assign the text object from the Canvas
    public float displayTime = 3f;    // Duration to show the text
    public bool singleUse = true;     // Optional: only show once per trigger

    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return; // Only trigger on player
        if (singleUse && triggered) return;

        triggered = true;
        StartCoroutine(ShowTutorial());
    }

    private IEnumerator ShowTutorial()
    {
        if (tutorialText != null)
            tutorialText.SetActive(true);   // Show the specific text

        yield return new WaitForSeconds(displayTime);

        if (tutorialText != null)
            tutorialText.SetActive(false);  // Hide after timer
    }
}
