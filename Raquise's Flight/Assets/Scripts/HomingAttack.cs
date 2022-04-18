using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingAttack : MonoBehaviour
{
    private GameObject target;

    private Rigidbody2D rb;

    public float speed = 15f;

    public float rotateSpeed = 125f;

    public GameObject explosionEffect;

    private GameObject player;

    private CameraShake shake;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player");
        SoundManager.PlaySound("SpawnThing");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (Vector2)target.transform.position - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotateSpeed;

            rb.velocity = transform.up * speed;
        }
    }

    

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Border")
        {
            Destroy(gameObject);
            SoundManager.PlaySound("explosionEffectSFX");
            GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosion2, 0.8f);
        }
      

        if (collision.tag == "Player")
        {
            Die();
        }

       // if (collision.tag == "Obstacle")
        //{

          //  GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

           // Destroy(explosion2, 0.8f);
       // }

        if (collision.tag == "Bullet")
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
        shake.CamShake();
        GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        ScoreManager.instance.AddPoint();
        Destroy(explosion2, 0.8f);
        SoundManager.PlaySound("explosionEffectSFX");
    }

}
