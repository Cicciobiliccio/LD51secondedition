using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    public float fireRatio;
    public Transform nozzle;
    float fireTimer;
    CharacterController controller;
    public float projectileSpeed;


    public bool discreteProjectile;
    public bool laser;
    public GameObject laserObj;
    LineRenderer lRenderer;

    public GameObject debrees;

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
        controller.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime);

        //Firing projectile
        if (discreteProjectile) {
            fireTimer -= Time.deltaTime;
            if (Input.GetButton("Fire1") && fireTimer <= 0)
            {
                fireTimer = 1 / fireRatio;

                GameObject proj = Instantiate(projectile, nozzle.position, Quaternion.identity);

                proj.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * projectileSpeed, ForceMode.Impulse);
            }
        }


        //Firing Lasers
        if (laser) {
            RaycastHit hit;
            if (Input.GetButton("Fire1"))
            {
                laserObj.SetActive(true);
                Vector3[] laserPositions = new Vector3[2];
                laserPositions[0] = nozzle.transform.position;
                Ray ray = new Ray(transform.position, transform.forward);
                if (Physics.Raycast(ray, out hit))
                {
                    //print(hit.transform.position);
                    Instantiate(debrees, hit.point, Quaternion.identity);

                    if (hit.transform != null)
                    {
                        laserPositions[1] = hit.point;
                        //lRenderer.SetPositions(laserPositions);
                    }
                    else {
                        print("wow");
                        laserPositions[1] = ray.GetPoint(20);
                    }
                    
                }
                
                lRenderer.SetPositions(laserPositions);
            }
            else {
                laserObj.SetActive(false);
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
}
