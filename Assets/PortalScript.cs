using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{

    public List<GameObject> enemyList = new List<GameObject>();
    public List<GameObject> portals = new List<GameObject>();
    public float spawntime;
    float timer;
    public int enemyNumber;

    void Start()
    {
        foreach (GameObject p in GameObject.FindGameObjectsWithTag ("Portal")) {
            portals.Add(p);
        }
    }


    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0) {
            timer = spawntime;
            for (int a = 0; a < enemyNumber; a++) {
                GameObject selectedPortal = portals[Random.Range(0, portals.Count)];
                GameObject selectedEnemy = enemyList[Random.Range(0, enemyList.Count)];
                Instantiate(selectedEnemy, selectedPortal.transform.position, Quaternion.identity);
            }
        }
    }
}
