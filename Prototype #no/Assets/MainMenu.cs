using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("HideAndSeek");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
