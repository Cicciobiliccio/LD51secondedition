using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeFromOptions : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    void Update (){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused) {
                ResumeOptions ();
            }
        }
    }

    public void ResumeOptions() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        FindObjectOfType<AudioManager>().StopPlaying("MenuMusic");
        FindObjectOfType<AudioManager>().Play("In-GameMusic");
    }

}
