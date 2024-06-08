using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
   
    public float speed = 0.7f;
    public float obstacleDetectDistance = 0.3f;
    public float detectRange = 1.5f;
    public float atkRange;
    private Transform target;
    private Rigidbody2D rb;
    public LayerMask obstacle, player;
    private Animator animator;
    
    void Start()
    {
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();    
        
    }

    void FixedUpdate()
    {
        Collider2D playerCollider =Physics2D.OverlapCircle(transform.position, detectRange, player);
        if (playerCollider != null)
        {


           
            Vector2 direction = (target.position - transform.position).normalized;
           
            
           
           
            
            RaycastHit2D hitObs = Physics2D.Raycast(transform.position, direction, obstacleDetectDistance,obstacle);
            if (hitObs.collider != null)
            {
              
                Vector2 obstacleAvoidanceDirection = -Vector2.Perpendicular(direction);
                rb.AddForce(obstacleAvoidanceDirection * speed);
                transform.localScale = getDirection(obstacleAvoidanceDirection);
            }
            else
            { 
            
                if(Vector2.Distance(target.position, transform.position)>atkRange+0.5)
                rb.AddForce(direction * speed);
                transform.localScale = getDirection(direction);

            }
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running",false);
        }
        
    }
    private Vector3 getDirection(Vector2 lookDirection)
    {
        Vector3 scale = transform.localScale;
        if (lookDirection.x > 0)
        {
            scale.x = 1;
        }
        else if (lookDirection.x < 0)
        {
            scale.x = -1;
        }
        return scale;
    }
}
