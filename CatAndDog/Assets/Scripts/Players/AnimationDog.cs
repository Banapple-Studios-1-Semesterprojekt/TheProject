using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDog : MonoBehaviour
{
    private Movement movement;
    private Animator animator;
    private Bark bark;


    void Start()
    {
        movement = GetComponent<Movement>();
        animator = GetComponent<Animator>();
        bark = GetComponentInChildren<Bark>();
    }

    // Update is called once per frame
    void Update()
    {
        //Walk
        if (Input.GetKey(movement.left) && movement.IsGrounded() || Input.GetKey(movement.right) && movement.IsGrounded())
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        //Jump
        if (Input.GetKeyUp(movement.up) && movement.IsGrounded())
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }

        //In air
        if (!movement.IsGrounded())
        {
            animator.SetBool("InAir", true);
        }
        else
        {
            animator.SetBool("InAir", false);
        }

        //Bark
        if(Input.GetKeyDown(KeyCode.RightShift) && bark.canBark && !bark.barkReset)
        {
            animator.SetTrigger("Bark");
        }
    }
}
