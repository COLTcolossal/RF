using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InvincCooldown : MonoBehaviour
{
    
    public float invincCooldown = 10f;
    public TextMeshPro counts;
    public GameObject Player;

    void Start()
    {
        
    }

   
    void FixedUpdate()
    {
       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CrossNecklace")
        {
            Enabled();

            for (int a = 0; a < transform.childCount; a++)
            {
                Player.transform.GetChild(5).gameObject.SetActive(true);

            }

        }
    }

    public void Enabled()
    {
        invincCooldown = 10;
        StartCoroutine(DisableRoutine());
    }

    IEnumerator DisableRoutine()
    {

        while (invincCooldown > 0)
        {
            counts.text = invincCooldown.ToString();

            yield return new WaitForSecondsRealtime(1);

            invincCooldown--;
        }

        if (invincCooldown == 0)
        {
            Player.transform.GetChild(5).gameObject.SetActive(false);
        }

    }
    
}
