using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Heart : MonoBehaviour
{
    public GameObject[] hearts;
    public int health;
    public GameObject CNacc;
    private bool invincibleEnabled = false;
    public float invincCooldown = 10f;
    public GameObject explosionEffect;
    public TextMeshPro counts;

    //public float durationMG = 30f;
    //public float durationSG = 30f;
    public GameObject player;
    public int damage = 1;
    public bool open = false;
    public SpriteRenderer sprite;
    private bool dead = false;
    public GameObject PauseButton;
    public SpriteRenderer playerRender;
    public SpriteRenderer CNrender;
    private float blinkTime = 0.1f;
    private float immunedTime;
    public float blink;
    public float immuned;


    void Start()
    {

       

    }



    void Update()
    {
       

            if (health < 1)
            {
                Destroy(hearts[0].gameObject);
                Die();
            }

            else if (health < 2)
            {
                Destroy(hearts[1].gameObject);
            }

            else if (health < 3)
            {
                Destroy(hearts[2].gameObject);
            }

            if (dead == true)
            {
                Destroy(hearts[0].gameObject);
                Destroy(hearts[1].gameObject);
                Destroy(hearts[2].gameObject);
            }

        if (immunedTime > 0)
        {
            invincibleEnabled = true;

            immunedTime -= Time.deltaTime;

                blinkTime -= Time.deltaTime;

                if (blinkTime <= 0)
                {
                    playerRender.enabled = !playerRender.enabled;
                    CNrender.enabled = !CNrender.enabled;

                    blinkTime = blink;
                }
                if (immunedTime <= 0)
                {
                    invincibleEnabled = false;
                    playerRender.enabled = true;
                    CNrender.enabled = true;
                }


        }

    }

    public void Die()
    {

        if (invincibleEnabled == false)
        {
            SoundManager.PlaySound("explosionEffectSFX");
            GameObject explosion2 = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            PauseButton.transform.gameObject.SetActive(false);
            Destroy(explosion2, 0.8f);
            Destroy(player);
            dead = true;
            
        }

    }


    public void InvincEnabled()
    {
        invincibleEnabled = true;

        StartCoroutine(InvincDisableRoutine());
    }

    IEnumerator InvincDisableRoutine()
    {
       


        while (invincCooldown > 0)
        {
            counts.text = invincCooldown.ToString();

            yield return new WaitForSecondsRealtime(1);

            invincCooldown--;
        }


        for (int a = 0; a < transform.childCount; a++)
        {
            CNacc.transform.GetChild(3).gameObject.SetActive(false);

        }
        open = false;

        invincibleEnabled = false;

        if(invincCooldown == 0)
        {
            CNacc.transform.GetChild(5).gameObject.SetActive(false);
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            TakeDamage(damage);
        }


        if (collision.tag == "MGpowerup")
        {

            player.GetComponent<MachineGun>().enabled = true;
            player.GetComponent<Shotgun>().enabled = false;
            //StartCoroutine(MGtime());
            player.GetComponent<Weapon>().enabled = false;
            SoundManager.PlaySound("powerUp");

        }

        if (collision.tag == "ShotgunPWR")
        {

            player.GetComponent<Shotgun>().enabled = true;
            player.GetComponent<MachineGun>().enabled = false;
            //StartCoroutine(SGtime());
            player.GetComponent<Weapon>().enabled = false;
            SoundManager.PlaySound("powerUp");
        }

        if (collision.tag == "BasicPWR")
        {

            player.GetComponent<Shotgun>().enabled = false;
            player.GetComponent<MachineGun>().enabled = false;
            ScoreManager.instance.AddPoint();
            player.GetComponent<Weapon>().enabled = true;
            SoundManager.PlaySound("powerUp");
        }


        if (collision.tag == "CrossNecklace")
        {
            InvincEnabled();

            CNacc.transform.GetChild(5).gameObject.SetActive(true);

            for (int a = 0; a < transform.childCount; a++)
            {
                CNacc.transform.GetChild(3).gameObject.SetActive(true);
                SoundManager.PlaySound("powerUp");
            }
            open = false;
        }


    }

   /* IEnumerator MGtime()
    {
        yield return new WaitForSeconds(durationMG);
        player.GetComponent<MachineGun>().enabled = false;
        player.GetComponent<Weapon>().enabled = true;

        


    } 

    IEnumerator SGtime()
    {
        yield return new WaitForSeconds(durationSG);
        player.GetComponent<Shotgun>().enabled = false;
        player.GetComponent<Weapon>().enabled = true; 
   
        

    } */

    void TakeDamage(int damage)
    {

        if (invincibleEnabled == false)
        {
            health -= damage;
            StartCoroutine(FlashRed());
            SoundManager.PlaySound("playerHurt");

            if (immunedTime <= 0)
            {

                immunedTime = immuned;
                playerRender.enabled = false;
                CNrender.enabled = false;

                blinkTime = blink;

            }

        }
    }

    public IEnumerator FlashRed()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        sprite.color = Color.white;
    }

}
