using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    public void TryAgain() {
        SceneManager.LoadScene("Scenes/Simone");
        FindObjectOfType<AudioManager>().Play("In-GameMusic");
        FindObjectOfType<AudioManager>().StopPlaying("MenuMusic");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Scenes/Elise");
        FindObjectOfType<AudioManager>().StopPlaying("In-GameMusic");
        FindObjectOfType<AudioManager>().Play("MenuMusic");
    }
}
