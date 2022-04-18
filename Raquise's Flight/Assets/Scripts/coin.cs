using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public float Speed;


    void Start()
    {
        
    }

   
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position += new Vector3(Speed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(this.gameObject);
        }

        if (collision.tag == "Player")
        {
            SoundManager.PlaySound("coinPickUp");
            ScoreManager.instance.AddPoint1();
            Destroy(this.gameObject);
        }

    }
}
