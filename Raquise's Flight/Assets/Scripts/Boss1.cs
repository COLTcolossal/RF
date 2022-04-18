using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    //public GameObject deathEffect;
    public int health = 10000;
    public SpriteRenderer sprite;
    public Slider healthBar;
    private GameObject player;
    public bool isInvulnerable = false;
    private Animator anim;
    public GameObject explosionEffect;
    public bool open = false;
    public GameObject boss1;
    
    private CameraShake shake1;


    public void TakeDamage(int damage)
    {
        SoundManager.PlaySound("hitHurt");
        if (isInvulnerable)
            return;
        
        health -= damage;

        if (health <= 0)
        {
            
            Die();
            
        }

        if (health <= 6000)
        {
            if (open)
            {
                for (int a = 0; a < transform.childCount; a++)
                {
                    boss1.transform.GetChild(2).gameObject.SetActive(true);

                }
                open = false;

                for (int a = 0; a < transform.childCount; a++)
                {
                    boss1.transform.GetChild(3).gameObject.SetActive(true);

                }
                open = false;

                for (int a = 0; a < transform.childCount; a++)
                {
                    boss1.transform.GetChild(1).gameObject.SetActive(false);

                }
                open = false;
            }
          
        }

    }

    void Die()
    {
        SoundManager.PlaySound("explosionEffectSFX");
        Destroy(gameObject);
        shake1.CamShake1();
        GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        ScoreManager.instance.AddPoint2();
        Destroy(explosion2, 0.8f);

    }

    


    void Start()
    {
        

        


        player = GameObject.FindGameObjectWithTag("Player");

        if (health >= 10000)
        {
            if (open)
            {
                for (int a = 0; a < transform.childCount; a++)
                {
                    boss1.transform.GetChild(2).gameObject.SetActive(false);

                }
                open = true;

            }
        }

        if (health >= 10000)
        {
            if (open)
            {
                for (int a = 0; a < transform.childCount; a++)
                {
                    boss1.transform.GetChild(3).gameObject.SetActive(false);

                }
                open = true;

            }
        }

    }

    private void Update()
    {
        healthBar.value = health;

        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInvulnerable)
            return;

        if (collision.tag == "Bullet")
        {
            StartCoroutine(FlashRed());
        }

    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    

}
