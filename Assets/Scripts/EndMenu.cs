using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndMenu : MonoBehaviour
{
    public bool PlayerWin = true;
    public TMP_Text endText;

    public void SetStatusText(bool PlayerWin) {
        if (PlayerWin==true) {
            endText.text = "YOU WON. CONGRATS!";
        }
        else {
            endText.text = "GAME OVER";
        }
    }

    public void TryAgain() {
        SceneManager.LoadScene("Scenes/Simone");
    }

    public void LoadMenu() {
        SceneManager.LoadScene("Scenes/Elise");
    }
}
