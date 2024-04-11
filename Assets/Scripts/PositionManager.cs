using UnityEngine;
using TMPro;

public class CarPositionTracker : MonoBehaviour
{
    public GameObject playerCar;
    public GameObject[] aiCars;
    public TextMeshProUGUI positionText;

    void Update()
    {
        // Ensure player car and at least one AI car are assigned
        if (playerCar == null || aiCars == null || aiCars.Length == 0)
        {
            Debug.LogWarning("Player car or AI cars not assigned!");
            return;
        }

        // Find the position of the player car among AI cars
        int playerPosition = 1;
        foreach (var aiCar in aiCars)
        {
            if (playerCar.transform.position.z < aiCar.transform.position.z)
            {
                playerPosition++;
            }
        }

        // Convert position number to ordinal
        string ordinalSuffix;
        switch (playerPosition)
        {
            case 1:
                ordinalSuffix = "st";
                break;
            case 2:
                ordinalSuffix = "nd";
                break;
            case 3:
                ordinalSuffix = "rd";
                break;
            default:
                ordinalSuffix = "th";
                break;
        }

        // Update the TextMeshPro text
        positionText.text = playerPosition + ordinalSuffix + " Position";
    }
}
