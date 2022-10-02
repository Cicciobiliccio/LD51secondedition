using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float playerMaxLife;
    public float playerCurrentLife;
    public GameObject healthBar;
    public GameObject projectile;
    public float fireRatio;
    public Transform nozzle;
    float fireTimer;
    CharacterController controller;
    public float projectileSpeed;


    public bool discreteProjectile;
    public bool laser;
    public float laserDamage;
    float laserTimer;
    public float laserFireRatio;
    public GameObject laserObj;
    LineRenderer lRenderer;

    public GameObject debrees;

    public float health;



    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        lRenderer = laserObj.GetComponent<LineRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        //movement
       // gameObject.transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        controller.Move(new Vector3(Input.GetAxisRaw("Horizontal"), -9, Input.GetAxisRaw("Vertical")) * speed * Time.deltaTime);
       

        //Firing projectile
        if (discreteProjectile) {

            fireTimer -= Time.deltaTime;
            if (Input.GetButton("Fire1") && fireTimer <= 0)
            {
                fireTimer = 1 / fireRatio;

                GameObject proj = Instantiate(projectile, nozzle.position, Quaternion.identity);
                FindObjectOfType<AudioManager>().Play("Bullet2");

                proj.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * projectileSpeed, ForceMode.Impulse);
            }
        }


        //Firing Lasers
        if (laser) {
            laserTimer -= Time.deltaTime;
            RaycastHit hit;
            if (Input.GetButton("Fire1"))
            {
                FindObjectOfType<AudioManager>().Play("LaserLong");
                laserObj.SetActive(true);
                Vector3[] laserPositions = new Vector3[2];
                laserPositions[0] = nozzle.transform.position;
                Ray ray = new Ray(transform.position, transform.forward);
                if (Physics.Raycast(ray, out hit, 50))
                {
                    //print(hit.transform.position);
                    Instantiate(debrees, hit.point, Quaternion.identity);

                    //print(hit.point);
                    if (hit.point != null)
                    {
                        laserPositions[1] = hit.point;
                        if (hit.transform.tag == "Enemy") {
                            
                            if (laserTimer <= 0) {
                                laserTimer = 1 / laserFireRatio;
                                hit.transform.GetComponent<Enemy1Behaviour>().TakeDamage(laserDamage);
                                //print("hit");
                            }
                            
                        }
                    }
                }

                else {
                    laserPositions[1] = ray.GetPoint(50);
                }
                lRenderer.SetPositions(laserPositions);
            }
            else {
                laserObj.SetActive(false);
                FindObjectOfType<AudioManager>().StopPlaying("LaserLong");
            }

        }
        
            

        // Rotate towards mouse
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        Vector3 objectPos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);

        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, -angle +90, 0));

    }

    public void PlayerDamage ()
    {
        playerCurrentLife--;
        healthBar.GetComponent<Slider>().value = (playerCurrentLife / playerMaxLife) * 10;

        if (playerCurrentLife <= 0) {
            print("you are dead");
            //FindObjectOfType<AudioManager>().Play(dienoices[Random.Range(0, dienoices.Count)]);
        }
    }

   
}
