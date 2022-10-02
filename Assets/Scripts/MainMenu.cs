using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour {
    
    public float timer=2;

    public void PlayGame ()
    {   
        while (timer>0) {
            timer -= Time.deltaTime;
        }
        Debug.Log("Play Game!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().StopPlaying("MenuMusic");
        FindObjectOfType<AudioManager>().Play("In-GameMusic");
        
    }

    public GameObject explosion;
    public Transform explosionPosition;

    public void explosionEffect ()
    {   
        Instantiate(explosion, explosionPosition.position, Quaternion.identity);
        FindObjectOfType<AudioManager>().Play("MenuClick");
    }

    public void QuitGame ()
    {   
        Debug.Log("QUIT!");
        Application.Quit();
    }



}
