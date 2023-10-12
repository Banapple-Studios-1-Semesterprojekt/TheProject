using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDog : MonoBehaviour
{
    public LayerMask ground;
    public LayerMask coPlayer;
    public float raylength = 1;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public float speed = 1f;
    public float jumpPower = 0f;

    public float jumpPowerX = 0.2f;
    public float jumpPowerY = 0.8f;

    private float colliderSize = 1;

    private bool jump = false;

    private float direction = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        colliderSize = gameObject.GetComponent<BoxCollider2D>().bounds.extents.x;
        //Get rigedbody frome gameobjekt
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyUp(up) && IsGrounded())
        {
            jump = true;
        }
    }

    //check if grounded
    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(colliderSize * .98f, raylength, 0), Vector2.right, (colliderSize) * 1.98f, ground);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(colliderSize * .98f, raylength, 0), Vector2.right, (colliderSize) * 1.98f, coPlayer);
        Debug.DrawRay(transform.position - new Vector3(colliderSize * .98f, raylength, 0), Vector2.right * (colliderSize) * 1.98f, Color.red, 1);
        if (hit == true)
        {
            if (hit.collider.CompareTag("Ground"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (hit2 == true)
        {
            if (hit2.collider.CompareTag("Dog") || hit2.collider.CompareTag("Cat"))
            {
                return true;
            }
            else
            {
                Debug.Log("okay");
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    //reset jump

    private void FixedUpdate()
    {
        //movment leaft right
        if (Input.GetKey(left) && IsGrounded())
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            direction = -1;
        }

        if (Input.GetKey(right) && IsGrounded())
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            direction = 1;
        }
        // Move up
        if (jump == true)
        {
            rb.AddForce(new Vector2(jumpPower * jumpPowerX * direction, jumpPower * jumpPowerY), ForceMode2D.Impulse);
            jump = false;
        }
    }
}