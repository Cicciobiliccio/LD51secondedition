using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGamePortalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Artem_winScene");
            FindObjectOfType<AudioManager>().Play("Victory");
            FindObjectOfType<AudioManager>().StopPlaying("In-GameMusic");
            FindObjectOfType<AudioManager>().Play("MenuMusic");

        }
    }
}
