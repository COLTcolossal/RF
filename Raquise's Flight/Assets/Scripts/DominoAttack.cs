using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DominoAttack : MonoBehaviour
{

    private GameObject player;
    public GameObject explosionEffect;
    private int health = 50;
    public SpriteRenderer sprite;
    private CameraShake shake;

    public void TakeDamage(int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Die();


        }

    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        SoundManager.PlaySound("SpawnThing");
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Border")
        {
           // GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

            //Destroy(explosion2, 0.8f);
            Destroy(gameObject);
        }


        if (collision.tag == "Player")
        {
            Die();
        }

        if (collision.tag == "Bullet")
        {
            StartCoroutine(FlashRed());
            // GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);

            //Destroy(explosion2, 0.8f);
            //Destroy(gameObject);
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

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

}
