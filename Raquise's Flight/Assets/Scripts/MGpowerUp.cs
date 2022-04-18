using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MGpowerUp : MonoBehaviour
{
    public GameObject pickupFX;
    public float time = 0.3f;
    //public Rigidbody rb;
    public float Speed;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }

        if (other.CompareTag("Border"))
        {
            Destroy(this.gameObject);
        }
    }

    void Pickup(Collider2D player)
    {
        GameObject Powerup1 = (GameObject)Instantiate(pickupFX, transform.position, transform.rotation);
        Destroy(Powerup1, 0.3f);



        Destroy(gameObject);
    }

  

}
