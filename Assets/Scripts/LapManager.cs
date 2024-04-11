using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LapManager : MonoBehaviour
{
    public static float LapTime = 0f;
    public TMP_Text LapTimeText;

    void Update()
    {
        LapTime += Time.deltaTime;
        DisplayLapTime();
    }

    void DisplayLapTime()
    {
        float minutes = Mathf.FloorToInt(LapTime / 60);
        float seconds = Mathf.FloorToInt(LapTime % 60);
        float milliseconds = (LapTime % 1) * 1000;

        LapTimeText.text = string.Format("{0:00}:{1:00}.{2:000}", minutes, seconds, milliseconds);
    }
}
