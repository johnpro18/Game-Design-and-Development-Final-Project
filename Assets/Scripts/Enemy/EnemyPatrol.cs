using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float enemySpeed;
    [SerializeField] private float idleDuration;

    [Header ("Animator")]
    [SerializeField] private Animator animator;

    private Vector3 initScale;
    private bool isMovingLeft;
    private float idleTimer;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        animator.SetBool("Run", false);
    }

    private void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        if(isMovingLeft)
        {
            if(enemy.position.x >= leftEdge.position.x)
            {
                MoveDirection(-1);
            }
            else
            {
                DirectionChange();
            }
        }
        else
        {
            if(enemy.position.x <= rightEdge.position.x)
            {
                MoveDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }
    }

    private void DirectionChange()
    {   
        animator.SetBool("Run", false);
        idleTimer += Time.deltaTime;

        if(idleTimer > idleDuration)
        {
            isMovingLeft = !isMovingLeft;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void MoveDirection(int direction)
    {
        animator.SetBool("Run", true);
        idleTimer = 0;
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * enemySpeed, enemy.position.y, enemy.position.z);
    }
}
