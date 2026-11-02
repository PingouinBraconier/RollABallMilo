using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Lvl_1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
