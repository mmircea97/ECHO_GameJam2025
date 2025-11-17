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


        SceneManager.LoadSceneAsync("Design full");
        //StopMusic();
        
    }

   
    public void QuitGame()
    {
        
        Application.Quit();
    }
}
