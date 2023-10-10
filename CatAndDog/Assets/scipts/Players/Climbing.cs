using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Climbing : MonoBehaviour
{
    private KeyCode up;
    private KeyCode leaft;
    private KeyCode right;
    private float gravety;
    public bool Startclimb = true;
    public bool Climb = false;
    private Rigidbody2D rb;
    private Movementcat MVcat;
    private float pos;
    // Start is called before the first frame update
    void Start()
    {
       
       MVcat= GetComponent<Movementcat>();
       up=MVcat.up;
       leaft=MVcat.leaft;
       right=MVcat.right;
       
       rb=gameObject.GetComponent<Rigidbody2D>();
        gravety = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Climb == true && Input.GetKeyDown(up)&&Startclimb==true&& MVcat.isgrounded())
        {
         MVcat.enabled = false;
         rb.AddForce(new Vector2(0,10), ForceMode2D.Impulse);
         rb.gravityScale = 0;
         rb.drag = 10;
         Startclimb = false;
         transform.position = new Vector2 (pos,transform.position.y);
        }

        
    }

    private void FixedUpdate()
    {
        if (Startclimb == false && Input.GetKey(up)&&Climb==true)
        {rb.velocity = new Vector2(0,5);}
        
        if (Startclimb == false && Input.GetKey(KeyCode.S))
        {rb.velocity = new Vector2(0, -5);}

        if (Input.GetKey(leaft)&&Startclimb==false)
        {
            StopClimp();

        }
        if (Input.GetKey(right) && Startclimb == false)
        {
            StopClimp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable")){
        Climb = true;
        pos=collision.transform.position.x;
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Climbable"))
        {
            Climb = false;
        }
    }
    private void StopClimp()
    {
        MVcat.enabled = true;
        rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        rb.gravityScale = gravety;
        rb.drag = 0;
        Startclimb = true;

    }
}
