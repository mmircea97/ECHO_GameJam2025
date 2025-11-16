using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    /*private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }*/

    public void PlayGame()
    {


        SceneManager.LoadSceneAsync("Test 2");
        //StopMusic();
        
    }

   
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
