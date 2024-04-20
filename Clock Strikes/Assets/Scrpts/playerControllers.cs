using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllers : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    private float movement;

    private Rigidbody2D ridB;
    private Animator animator;
    
    public bool isJumping;
    private bool isChangingAngle;


    void Start()
    {
        ridB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        movement = Input.GetAxis("Horizontal");

        ridB.velocity = new Vector2( speed * movement, ridB.velocity.y );

        
        //Add force to jump
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            ridB.AddForce( new Vector2 (ridB.velocity.x, jumpHeight) );
        }

        //if is walking load walking animation
        if (movement != 0)
        {
            animator.SetBool("isWalking", true); 
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
        //loads jumping anim
        animator.SetBool("isJumping", isJumping);

        if (!isChangingAngle && movement < 0) 
        { 
           PlayerChanging();
        }
        if (isChangingAngle && movement > 0)
        {
            PlayerChanging();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.CompareTag("tile"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D otherCollision)
    {
        if (otherCollision.gameObject.CompareTag("tile"))
        {
            isJumping =true;
        }
    }

    private void PlayerChanging()
    {
        isChangingAngle = !isChangingAngle;

        Vector3 flipInX = transform.localScale;
        flipInX.x *= -1;

        transform.localScale = flipInX;
    }
}
