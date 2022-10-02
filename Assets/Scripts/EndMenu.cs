using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public static bool GameOver = true;

    public void TryAgain() {
        SceneManager.LoadScene("Scenes/Simone");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Scenes/Elise");
    }
}
