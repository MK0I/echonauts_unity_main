using UnityEngine;

public class pause_menu : MonoBehaviour
{
    public GameObject container;

    private bool isPaused = false;

    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else Pause();
    }

    public void Pause()
    {
        container.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Resume()
    {
        container.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /*public void QuitGame()
    {
        Application.Quit();
    }*/
}