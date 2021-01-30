
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class MainMenu : MonoBehaviour
{
    int level;
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Play()
    {
        //Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("Level1");
        level = 1;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void About()
    {
        SceneManager.LoadScene("About");
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
