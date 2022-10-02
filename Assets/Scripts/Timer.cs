using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public int periodCounter = 0;
    public TMP_Text timeText;
    public GameObject timerBar;

    void Update()
    {
        if (timeRemaining >= 0)
        {
            timeRemaining -= Time.deltaTime;
            SetTimerBar(timeRemaining);
            DisplayTime(timeRemaining);
        }
        else
        {
            Debug.Log("Time has run out!");
            timeRemaining = 10;
            periodCounter += 1;
            SetTimerBar(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //Debug.Log(timeToDisplay);
        if (timeToDisplay < 1) {
            timeText.text = "RESET";
        }
        else {
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            timeText.text = string.Format("{00}", seconds);
        }
    }

    public void SetTimerBar (float timeRemaining)
    {
        timerBar.GetComponent<Slider>().value = timeRemaining/10;
    }
}




