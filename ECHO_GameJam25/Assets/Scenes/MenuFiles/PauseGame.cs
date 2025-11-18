using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class PauseGame : MonoBehaviour
{

    [SerializeField]
    private Canvas pauseCanvas;
    
    
    private bool isPaused;
    void Start()
    {
        isPaused = false;
        pauseCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0;
            pauseCanvas.enabled = true;
        }

        if (!isPaused)
        {
            Time.timeScale = 1;
            pauseCanvas.enabled = false;
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
