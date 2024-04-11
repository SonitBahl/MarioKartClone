using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public string sceneName = "MainMenu"; // Name of the scene to load

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player (you can modify this condition as needed)
        if (other.CompareTag("FinishLine"))
        {
            // Load the scene specified by sceneName
            SceneManager.LoadScene(sceneName);
        }
    }
}
