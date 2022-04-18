using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    
    //public GameObject deathEffect;
    public int health = 100;
    public SpriteRenderer sprite;
    public GameObject gatXplodefx;
    // public float speed = 20f;
    // public Rigidbody2D rb;
    private CameraShake shake;



    public void TakeDamage (int damage)
 

    {
        health -= damage;

        if (health <= 0)
        {
            
            Die();
            
        }
    }

    void Die ()
    {
        shake.CamShake();
        Destroy(gameObject);
        ScoreManager.instance.AddPoint();
        GameObject gatXplode = (GameObject)Instantiate(gatXplodefx, transform.position, transform.rotation);
        SoundManager.PlaySound("gatXplode");
        Destroy(gatXplode, 0.6f);

    }
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<CameraShake>();
        player = GameObject.FindGameObjectWithTag("Player");
        //rb.velocity = -transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Bullet")
        {
            StartCoroutine(FlashRed());
          
        }

        else if (collision.tag == "Player")
        {
            Die();
        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }
   
  
}
