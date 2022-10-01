using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy1Behaviour : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject player;
    public float currentLife;
    public Slider lifeSlider;
    public float maxLife;
    public float attackDistance;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        currentLife = maxLife;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;

        if (agent.remainingDistance <= attackDistance)
        {
            anim.SetBool("Attacking", true);
        }
        else {
            anim.SetBool("Attacking", false);
        }
    }

    public void TakeDamage(float damage) {
        currentLife -= damage;
        if (currentLife <= 0) {
            Destroy(gameObject);
        }
        lifeSlider.value = (currentLife / maxLife) *10;
    }

    public void DamagePlayer() {
        player.GetComponent<PlayerController>().PlayerDamage();
    }
}
