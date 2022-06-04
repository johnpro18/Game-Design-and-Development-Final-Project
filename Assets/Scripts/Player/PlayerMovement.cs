using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f; 
    [SerializeField] private float dashSpeed = 20f; 
    
    protected Rigidbody2D body;
    protected Animator animator;

    Vector2 movement;
    bool isFacingRight = true;

    private float activeMovementSpeed;
    private float dashCounter;
    private float dashCoolCounter;
    private float dashLength = 0.3f;
    private float dashCooldown = 1f;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        activeMovementSpeed = movementSpeed;  
    }

    private void Update()
    {
        if(movement.x > 0 && isFacingRight == false)
        {
            FlipCharacter();
        }
        else if(movement.x < 0 && isFacingRight == true)
        { 
            FlipCharacter();
        }

        DashCharacter();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
        UpdateAnimations();
    }

    //Basic Charcter Movement
    private void MoveCharacter()
    {   
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        body.MovePosition(body.position + movement * activeMovementSpeed * Time.fixedDeltaTime);
    }

    //Character Movement Animations
    private void UpdateAnimations()
    {
        if(Mathf.Abs(movement.x) > 0.1f || Mathf.Abs(movement.y) > 0.1f)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }

    //Character Flip
    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    //Character Dash
    private void DashCharacter()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMovementSpeed = dashSpeed;
                dashCounter = dashLength;
            }
        }

        if(dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if(dashCounter <= 0)
            {
                activeMovementSpeed = movementSpeed;
                dashCoolCounter = dashCooldown;
            }
        }

        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
}
