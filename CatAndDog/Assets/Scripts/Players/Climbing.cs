using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing : MonoBehaviour
{
    private KeyCode up;
    private KeyCode left;
    private KeyCode right;
    private float gravity;
    public bool startClimb = true;
    public bool climb = false;
    private Rigidbody2D rb;
    private Movement moveCat;

    // objectets position
    private float pos;

    // Start is called before the first frame update
    private void Start()
    {
        //set Key = cat movment keys
        moveCat = GetComponent<Movement>();
        up = moveCat.up;
        left = moveCat.left;
        right = moveCat.right;
        //get rigedbody
        rb = gameObject.GetComponent<Rigidbody2D>();
        gravity = rb.gravityScale;
    }

    // Update is called once per frame
    private void Update()
    {
        // Hvis du kan kladtre og trykker up start med at klatre
        if (climb == true && Input.GetKeyDown(up) && startClimb == true && moveCat.IsGrounded())
        {
            moveCat.enabled = false;
            rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            rb.gravityScale = 0;
            rb.drag = 10;
            startClimb = false;
            transform.position = new Vector2(pos, transform.position.y);
        }
    }

    private void FixedUpdate()
    {
        // hvis du klatre kan du gå op og ned med key up og down
        if (startClimb == false && Input.GetKey(up) && climb == true)
        { rb.velocity = new Vector2(0, 5); }

        if (startClimb == false && Input.GetKey(KeyCode.S))
        { rb.velocity = new Vector2(0, -5); }

        // hvis du klatre og prøver at gå til side stop med at klatre
        if (Input.GetKey(left) && startClimb == false)
        {
            StopClimp();
        }
        if (Input.GetKey(right) && startClimb == false)
        {
            StopClimp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // hvis du colidere med en overflade du kan klatre på sæt climb til true
        if (collision.CompareTag("Climbable"))
        {
            climb = true;
            pos = collision.transform.position.x;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // hvis du Stopper colidere med en overflade du kan klatre på sæt climb til true
        if (collision.CompareTag("Climbable"))
        {
            climb = false;
        }
    }

    private void StopClimp()
    {
        //stop med at klatrer
        moveCat.enabled = true;
        moveCat.jumpPower = moveCat.Cat_jumpMinPower;
        rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        rb.gravityScale = gravity;
        rb.drag = 0;
        startClimb = true;
    }
    public void stopclimp()
    {
        moveCat.enabled = true;
        moveCat.jumpPower = moveCat.Cat_jumpMinPower;
        rb.gravityScale = gravity;
        rb.drag = 0;
        startClimb = true;

    }
}