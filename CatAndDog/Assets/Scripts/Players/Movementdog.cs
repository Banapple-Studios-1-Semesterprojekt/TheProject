using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDog : MonoBehaviour
{
    public LayerMask ground;
    public LayerMask coPlayerLayer;
    public float rayLength = 1;

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
    private BoxCollider2D boxCol;

    public static MovementDog instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        colliderSize = GetComponent<BoxCollider2D>().size.x;
        boxCol = GetComponent<BoxCollider2D>();
        //Get rigedbody from gameobjekt
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
        Vector3 rayPoint = transform.position + Vector3.down * boxCol.bounds.extents.y;
        Vector2 boxSize = new Vector2(boxCol.bounds.extents.x * 2, 0.3f);
        Collider2D hit2D = Physics2D.OverlapBox(rayPoint, boxSize, 0, ground);

        return hit2D != null;
    }

    //reset jump

    private void FixedUpdate()
    {
        //movment left right
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