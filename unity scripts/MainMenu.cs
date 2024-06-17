using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Load the next scene or the game scene
        SceneManager.LoadScene("GameScene");
    }

    public void ExitGame()
    {
        // Quit the application
        Application.Quit();
    }
}