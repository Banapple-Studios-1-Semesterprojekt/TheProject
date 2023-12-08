using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public LayerMask ground;
    public LayerMask coPlayerLayer;
    private bool IsCat=false;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode Cat_down;

    public float speed = 1f;
    public float jumpPower = 0f;
    public float Cat_jumpMaxPower = 1f;
    public float Cat_jumpMinPower = 1f;
    public float Cat_jumpBuildUpSpeed = 1f;
    public float jumpPowerX = 0.2f;
    public float jumpPowerY = 0.8f;
    private bool isJumping = false;
    private Vector2 boxColliderSize;

    private float colliderSize = 1;
    private bool jump = false;
    private float direction = 1;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;
    private SpriteRenderer visualSprite;

    //events
    public delegate void CatJumpAction();
    public event CatJumpAction onPlayerJump;

    // Start is called before the first frame update
    private void Awake()
    {
        //Get rigedbody from gameobjekt
        rb = GetComponent<Rigidbody2D>();
        visualSprite = GetComponent<SpriteRenderer>();
        
    }

    void Start()
    {
        //hvis tagget på gamobject er cat sæt iscat til true
        if (transform.CompareTag("Cat"))
        {
            IsCat = true;
        }
        if (IsCat)
        {
        jumpPower = Cat_jumpMinPower;
        }
        
        colliderSize = GetComponent<BoxCollider2D>().size.x;
        boxColliderSize = GetComponent<BoxCollider2D>().size;
        boxCol = GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
        // If iscat og isgrounded  og du trykker cat_down ned Så set kattens boxcolider til havld størelse, hvis ikke reset boxcolider
        if (Input.GetKeyDown(Cat_down) && IsCat && IsGrounded())
        {
            boxCol.size = boxColliderSize / 2;
        }
        if (Input.GetKeyUp(Cat_down) && IsCat)
        {
            boxCol.size = boxColliderSize;
        }

        //Activate jump
        if (IsCat == true)
        {
            if (Input.GetKey(up) && IsGrounded() && jumpPower < Cat_jumpMaxPower)
            {
                jumpPower += Cat_jumpBuildUpSpeed * Time.deltaTime;
            }
            if (Input.GetKeyUp(up) && IsGrounded())
            {
                jump = true;
            }
        }else
        {
            if (Input.GetKeyUp(up) && IsGrounded() && delayJumpCoroutine == null)
            {

                delayJumpCoroutine = StartCoroutine(DelayJump());
            }
        }

        UpdateSpriteFlip();
    }

    private void UpdateSpriteFlip()
    {
        if(rb.velocity.x < -0.1f ) { visualSprite.flipX = true; }
        else if(rb.velocity.x > 0.1f ) { visualSprite.flipX = false; }
    }

    Coroutine delayJumpCoroutine;
    IEnumerator DelayJump()
    {
        jump = true;
        isJumping = true;
        yield return new WaitForSeconds(1f);
        delayJumpCoroutine = null;
        isJumping = false;
    }

    //check if grounded
    public bool IsGrounded()
    {
        Vector3 rayPoint = transform.position + Vector3.down * (boxCol.bounds.extents.y-boxCol.offset.y);
        Vector2 boxSize = new Vector2(boxCol.bounds.extents.x * 2, 0.8f);
        Collider2D hit2D = Physics2D.OverlapBox(rayPoint, boxSize, 0, ground);

        return hit2D != null;
    }

    private void FixedUpdate()
    {
        if (IsCat == true)
        {
            //movement left right kat
            if (Input.GetKey(left) && jumpPower == Cat_jumpMinPower)
            {
                rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
                direction = -1;
            }

            if (Input.GetKey(right) && jumpPower == Cat_jumpMinPower)
            {
                rb.velocity = new Vector3(speed, rb.velocity.y, 0);
                direction = 1;
            }

            // Move up kat
            if (jump == true)
            {
                rb.AddForce(new Vector2(jumpPower * jumpPowerX * direction, jumpPower * jumpPowerY), ForceMode2D.Impulse);
                jump = false;
                jumpPower = Cat_jumpMinPower;

                //event call
                onPlayerJump?.Invoke();
            }
        }
        else
        {
            //movment left right hund
            if (Input.GetKey(left) && IsGrounded() && !isJumping)
            {
                rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
                direction = -1;
            }

            if (Input.GetKey(right) && IsGrounded() && !isJumping)
            {
                rb.velocity = new Vector3(speed, rb.velocity.y, 0);
                direction = 1;
            }

            // Move up hund
            if (jump == true)
            {
                if(Input.GetKey(left)|| Input.GetKey(right))
                {
                rb.AddForce(new Vector2(jumpPower * jumpPowerX * direction, jumpPower * jumpPowerY), ForceMode2D.Impulse);
                jump = false;

                //event call
                onPlayerJump?.Invoke();
                }
                else
                {
                    rb.AddForce(new Vector2(jumpPower * .05f * direction, jumpPower * jumpPowerY), ForceMode2D.Impulse);
                    jump = false;

                    //event call
                    onPlayerJump?.Invoke();

                }

            }

        }
    }
    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }

}

