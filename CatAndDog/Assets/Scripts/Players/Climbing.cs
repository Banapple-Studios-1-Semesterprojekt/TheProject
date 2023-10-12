using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Climbing : MonoBehaviour
{
    private KeyCode Up;
    private KeyCode Leaft;
    private KeyCode Right;
    private float Gravety;
    public bool Startclimb = true;
    public bool Climb = false;
    private Rigidbody2D rb;
    private Movementcat MVcat;
   // objectets position
    private float Pos;
    // Start is called before the first frame update
    void Start()
    {
       //set Key = cat movment keys
       MVcat= GetComponent<Movementcat>();
       Up=MVcat.up;
       Leaft=MVcat.leaft;
       Right=MVcat.right;
       //get rigedbody
       rb=gameObject.GetComponent<Rigidbody2D>();
        Gravety = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        // Hvis du kan kladtre og trykker up start med at klatre
        if (Climb == true && Input.GetKeyDown(Up)&&Startclimb==true&& MVcat.isgrounded())
        {
         MVcat.enabled = false;
         rb.AddForce(new Vector2(0,10), ForceMode2D.Impulse);
         rb.gravityScale = 0;
         rb.drag = 10;
         Startclimb = false;
         transform.position = new Vector2 (Pos,transform.position.y);
        }

        
    }

    private void FixedUpdate()
    {
        // hvis du klatre kan du gå op og ned med key up og down
        if (Startclimb == false && Input.GetKey(Up)&&Climb==true)
        {rb.velocity = new Vector2(0,5);}
        
        if (Startclimb == false && Input.GetKey(KeyCode.S))
        {rb.velocity = new Vector2(0, -5);}

        // hvis du klatre og prøver at gå til side stop med at klatre
        if (Input.GetKey(Leaft)&&Startclimb==false)
        {
            StopClimp();

        }
        if (Input.GetKey(Right) && Startclimb == false)
        {
            StopClimp();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // hvis du colidere med en overflade du kan klatre på sæt climb til true
        if (collision.CompareTag("Climbable")){
        Climb = true;
        Pos=collision.transform.position.x;
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        // hvis du Stopper colidere med en overflade du kan klatre på sæt climb til true
        if (collision.CompareTag("Climbable"))
        {
            Climb = false;
        }
    }
    private void StopClimp()
    {
        //stop med at klatrer 
        MVcat.enabled = true;
        MVcat.JumpPower = MVcat.Jumpminpower;
        rb.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
        rb.gravityScale = Gravety;
        rb.drag = 0;
        Startclimb = true;

    }
}
