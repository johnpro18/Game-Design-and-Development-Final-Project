using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    public AIPath aiPath;
    protected Animator animator;

    bool isFacingRight = true;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(aiPath.desiredVelocity.x > 0 && isFacingRight == false)
        {
            FlipCharacter();
        }
        else if(aiPath.desiredVelocity.x < 0 && isFacingRight == true)
        { 
            FlipCharacter();
        }
    }

    private void FixedUpdate()
    {
        UpdateAnimations();
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    private void UpdateAnimations()
    {
        if(Mathf.Abs(aiPath.desiredVelocity.x) > 0.1f || Mathf.Abs(aiPath.desiredVelocity.y) > 0.1f)
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
