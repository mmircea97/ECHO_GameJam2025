using UnityEngine;
using UnityEngine.SceneManagement;

public class Back : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
    }

    public void LinkOpener()
    {
        Application.OpenURL("https://www.mediafire.com/file/i0ayozua1o5iyin/AcceptanceDifficultVersion.rar/file");
    }
}
