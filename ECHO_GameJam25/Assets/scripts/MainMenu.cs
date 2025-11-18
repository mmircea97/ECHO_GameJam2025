using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    public void CreditScreen()
    {
        SceneManager.LoadSceneAsync("CreditsScreen");
    }

    public void HOFScreen()
    {
        SceneManager.LoadSceneAsync("HallOfFame");
    }

   
    public void QuitGame()
    {
        
        Application.Quit();
    }
    
    
}
