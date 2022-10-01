using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float lifespan;
    public GameObject debree;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") {
            //print("ups");
            Instantiate(debree, transform.position, Quaternion.identity);
            other.transform.GetComponent<Enemy1Behaviour>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
