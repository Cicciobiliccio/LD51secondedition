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
    
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        controller.SimpleMove(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime);

        //firing
        fireTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && fireTimer <= 0) {
            fireTimer = 1 / fireRatio;

            GameObject proj = Instantiate(projectile, nozzle.position, Quaternion.identity);

            proj.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * projectileSpeed, ForceMode.Impulse);
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
