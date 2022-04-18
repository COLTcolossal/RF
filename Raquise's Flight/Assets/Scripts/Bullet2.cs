using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    //public float speed = 20f;
    public int damage = 50;
    public Rigidbody2D rb;
    public GameObject BulletExplode;


    void Start()
    {
        SoundManager.PlaySound("GunShot");

    }

    void FixedUpdate()
    {
        //rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Obstacle obstacle = hitInfo.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            GameObject explosion = (GameObject)Instantiate(BulletExplode, transform.position, transform.rotation);
            SoundManager.PlaySound("hitHurt");
            obstacle.TakeDamage(50);
            Destroy(explosion, 0.4f);

            Destroy(gameObject);
        }


        Boss1 boss1 = hitInfo.GetComponent<Boss1>();
        if (boss1 != null)
        {
            GameObject explosion = (GameObject)Instantiate(BulletExplode, transform.position, transform.rotation);

            boss1.TakeDamage(50);
            Destroy(explosion, 0.4f);

            Destroy(gameObject);
        }

        DominoAttack domino = hitInfo.GetComponent<DominoAttack>();
        if (domino != null)
        {
            GameObject explosion = (GameObject)Instantiate(BulletExplode, transform.position, transform.rotation);

            domino.TakeDamage(50);
            Destroy(explosion, 0.4f);

            Destroy(gameObject);
        }

        
        

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Border")
        {

            Destroy(gameObject);
        }
    }

}
