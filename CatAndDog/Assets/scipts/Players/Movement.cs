using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public LayerMask jord;
    public LayerMask medspillerlag;
    public float raylength = 1;
    public KeyCode leaft;
    public KeyCode right;
    public KeyCode up;
    public float Speed = 1f;
    public float JumpPower = 1f;
    public float JumpTime = 1f;
    private bool jumpdelay = false;
    private bool jump = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        //Get rigedbody frome gameobjekt
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //jump input
        if (Input.GetKeyDown(up) && jumpdelay == false && isgrounded())
        {
            jumpdelay = true;
            jump = true;
            Invoke("jumpreset", JumpTime);
        }
        if (Input.GetKeyUp(up))
        {
            jump = false;
        }
    }

    //check if grounded
    private bool isgrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position - new Vector3(gameObject.GetComponent<BoxCollider2D>().size.x / 2 * .98f, raylength, 0), Vector2.right, (gameObject.GetComponent<BoxCollider2D>().size.x) * .98f, jord);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position - new Vector3(gameObject.GetComponent<BoxCollider2D>().size.x / 2 * .98f, raylength, 0), Vector2.right, (gameObject.GetComponent<BoxCollider2D>().size.x) * .98f, medspillerlag);
        Debug.DrawRay(transform.position - new Vector3(gameObject.GetComponent<BoxCollider2D>().size.x / 2 * .98f, raylength, 0), Vector2.right * (gameObject.GetComponent<BoxCollider2D>().size.x) * .98f, Color.red, 1);
        if (hit == true)
        {
            if (hit.collider.tag == "jord")
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
            if (hit2.collider.tag == "dog" || hit2.collider.tag == "cat")
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
    private void jumpreset()
    {
        jump = false;
        jumpdelay = false;
    }

    private void FixedUpdate()
    {
        //movment leaft right
        if (Input.GetKey(leaft))
        {
            rb.velocity = new Vector3(-Speed, rb.velocity.y, 0);
        }

        if (Input.GetKey(right))
        {
            rb.velocity = new Vector3(Speed, rb.velocity.y, 0);
        }

        // Move up
        if (jump == true)
        {
            rb.AddForce(new Vector2(0, JumpPower), ForceMode2D.Impulse);
        }
    }
}