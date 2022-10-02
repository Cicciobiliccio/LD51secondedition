using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 11;
    public int periodCounter = 0;
    public TMP_Text timeText;
    void Update()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 11;
            periodCounter += 1;
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        Debug.Log(timeToDisplay);
        if (timeToDisplay < 1) {
            timeText.text = "RESET";
        }
        else {
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{00}", seconds);
        }
    }
}