using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borders : MonoBehaviour
{
    private GameObject MGpower;
    private GameObject CNpower;
    private GameObject bullet;

    void OnTriggerEnter2D(Collider2D collision)
    {

        CNpower = GameObject.FindGameObjectWithTag("CrossNecklace");
        MGpower = GameObject.FindGameObjectWithTag("MGpowerup");
        bullet = GameObject.FindGameObjectWithTag("Bullet");
        if (collision.tag == "Bullet")
        {
            // GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

            // Destroy(explosion2, 0.8f);
            Destroy(bullet);
        }

        if(collision.tag == "CrossNecklace")
        {
            // GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

            // Destroy(explosion2, 0.8f);
            Destroy(CNpower);
        }

        if(collision.tag == "MGpowerup")
        {
            // GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

            // Destroy(explosion2, 0.8f);
            Destroy(MGpower);
        }

    }
}
