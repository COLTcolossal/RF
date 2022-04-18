using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class money : MonoBehaviour
{
    //public GameObject coinFX;


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.GetComponent<coin>())
        {
            SoundManager.PlaySound("coinPickUp");
            ScoreManager.instance.AddPoint1();
            Destroy(collision.gameObject);
            /* GameObject CoinGrab = (GameObject)Instantiate(coinFX, transform.position, transform.rotation);

            Destroy(CoinGrab, 0.3f);  */


        }

    }
}
