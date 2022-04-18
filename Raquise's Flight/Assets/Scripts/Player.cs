using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public float playerSpeedX;
    private Rigidbody2D rb;
    private Vector2 playerDirection;
    public Animator animator;
    
   
    
    public GameObject player;
    
    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        
        

    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(0, playerDirection.y * playerSpeed);

        playerDirection.y = Input.GetAxisRaw("Vertical");
        playerDirection = new Vector2(0, playerDirection.y).normalized;

        animator.SetFloat("Vertical", playerDirection.y);
        animator.SetFloat("Speed", playerDirection.sqrMagnitude);

        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * playerSpeedX;


    }

    

    
}
