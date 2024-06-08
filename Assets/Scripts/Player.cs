using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 moveDelta;
    // private RaycastHit2D hit;

    public Animator animator;
    public float speed = 1f;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal"), y = Input.GetAxisRaw("Vertical");

        if (x == 0 && y == 0)
            animator.SetBool("isRunning", false);
        else
            animator.SetBool("isRunning", true);

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        if (moveDelta.magnitude > 1)
        {
            moveDelta.Normalize();
        }
        transform.Translate(moveDelta * Time.deltaTime * speed);
    }
}
