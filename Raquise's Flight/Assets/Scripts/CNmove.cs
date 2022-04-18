using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNmove : MonoBehaviour
{

    public Animator animator;
    private Vector2 playerDirection;
    private Rigidbody2D rb;
    public float playerSpeed;


    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        playerDirection.y = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, playerDirection.y).normalized;

        animator.SetFloat("Vertical", playerDirection.y);
        animator.SetFloat("Speed", playerDirection.sqrMagnitude);

    }

    void FixedUpdate()
    {
        //rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);

    }

}
