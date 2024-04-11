using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to be called when the "Play Game" button is clicked
    public void PlayGame()
    {
        // Load Scene1
        SceneManager.LoadScene("SampleScene");
    }

    // Method to be called when the "Quit Game" button is clicked
    public void QuitGame()
    {
        // Quit the application (works in standalone builds)
        Application.Quit();
    }
}
