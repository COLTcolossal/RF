using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GatlenCurse : MonoBehaviour
{
    //public GameObject deathEffect;
    public int health = 50;
    
    public GameObject gatXplodefx;
    // public float speed = 20f;
    
    float originalY;

    public float floatStrength = 1;
    public float Speed;
    public float time = 0.4f;



    void FixedUpdate()
    {

        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);

        transform.position = new Vector3(transform.position.x,
            originalY + ((float)Math.Sin(Time.time) * floatStrength),
            transform.position.z) ;
        transform.Translate(0, 1, 0);


    }




    public void TakeDamage(int damage)


    {
        health -= damage;

        if (health <= 0)
        {

            Die();

        }
    }

    void Die()
    {
        
        Destroy(gameObject);
        ScoreManager.instance.AddPoint();
        GameObject gatXplode = (GameObject)Instantiate(gatXplodefx, transform.position, transform.rotation);
        SoundManager.PlaySound("GCxplode");
        Destroy(gatXplode, 0.6f);

    }
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.originalY = this.transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
        //rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Bullet")
        {
            Die();

        }

        else if (collision.tag == "Player")
        {
            Die();
        }
    }

   
   

}
