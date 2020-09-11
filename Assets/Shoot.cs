using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    //private Rigidbody2D projectileRb;
    public Transform firePoint;
    public float fireSpeed = 500f;

    public AudioSource BowSound;

    // Start is called before the first frame update
    void Start()
    {
        //projectileRb = projectile.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            print("spacebar");
            Fire();
        }
    }

    public void Fire()
    {
        //var test = Instantiate(projectileRb, firePoint.position, firePoint.rotation);
        //test.AddForce(firePoint.forward * fireSpeed);

        Instantiate(projectile, firePoint.position, firePoint.rotation);
        BowSound.Play();
    }
}

