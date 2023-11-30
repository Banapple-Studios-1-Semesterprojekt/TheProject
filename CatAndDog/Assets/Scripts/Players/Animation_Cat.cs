using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Cat : MonoBehaviour
{
    private Movement movement;
    private Animator animator;
    private Climbing climbing;
    void Start()
    {
        climbing = GetComponent<Climbing>();
        movement=GetComponent<Movement>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // climb Animation
        if (climbing.climb)
        {
            animator.SetBool("Climb", true);
            if (Input.GetKey(movement.Cat_down))
            {
                animator.SetBool("Climb_down", true);
                animator.SetBool("Climb_up", false);
            }else if (Input.GetKey(movement.up))
            {
                animator.SetBool("Climb_down", false);
                animator.SetBool("Climb_up", true);
            }
            else
            {
                animator.SetBool("Climb_down", false);
                animator.SetBool("Climb_up", false);
            }
        }
        else
        {
            animator.SetBool("Climb", false);
            animator.SetBool("Climb_down", false);
            animator.SetBool("Climb_up", false);
        }
       
        //duck Animation
        if (Input.GetKeyDown(movement.Cat_down) && movement.IsGrounded()&&!climbing.climb)
        {
            animator.SetBool("Duck", true);
        }
        if (Input.GetKeyUp(movement.Cat_down))
        {
            animator.SetBool("Duck", false);
        }

        // Jump Animation
        if (Input.GetKeyDown(movement.up) && movement.IsGrounded() && !climbing.climb)
        {
            animator.SetBool("Duck", false);
            animator.SetBool("Run", false);
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyUp(movement.up))
        {
            animator.SetBool("Jump", false);
        }

        // In Air Animation
        if (movement.IsGrounded())
        {
            animator.SetBool("Inair", false);
        }
        else
        {
            animator.SetBool("Inair", true);
        }

        //Movement left/right Animation   
        if (Input.GetKey(movement.left) && movement.IsGrounded() || Input.GetKey(movement.right) && movement.IsGrounded())
        {
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
