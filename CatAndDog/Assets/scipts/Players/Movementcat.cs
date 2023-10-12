using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
public class Movementcat : MonoBehaviour
{
    public LayerMask jord;
    public LayerMask medspillerlag;
    public float raylength = 1;
    private float colidersize = 1;
    private BoxCollider2D boxCol;
    public KeyCode leaft;
    public KeyCode right;
    public KeyCode up;
    public float Speed = 1f;
    public float JumpPower = 0f;
    public float JumpMaxpower = 1f;
    public float Jumpminpower = 1f;
    public float Jumpbuildupspeed = 1f;
    private bool jump = false;
    public float JumpPowerX = 0.2f;
    public float JumpPowerY = 0.8f;
    private float diretion = 1;
    private Rigidbody2D rb;

    public static Movementcat instance;

    private void Awake()
    {
        instance = this;

        //Get rigedbody frome gameobjekt
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        JumpPower = Jumpminpower;
        colidersize = gameObject.GetComponent<BoxCollider2D>().size.x;
        //Get rigedbody from gameobjekt
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        

        //jump input
        if (Input.GetKey(up) && isgrounded() && JumpPower < JumpMaxpower)
        {

            JumpPower += Jumpbuildupspeed * Time.deltaTime;


        }
        if (Input.GetKeyUp(up) && isgrounded())
        {
            jump = true;
        }
    }

    //check if grounded 
    public bool isgrounded()
    {
        Vector3 rayPoint = transform.position + Vector3.down * boxCol.bounds.extents.y;
        Vector2 boxSize = new Vector2(boxCol.bounds.extents.x * 2, 0.3f);
        Collider2D hit2D = Physics2D.OverlapBox(rayPoint, boxSize, 0, jord);

        return hit2D != null;
    }

    //reset jump 

    private void FixedUpdate()
    {

        //movment leaft right
        if (Input.GetKey(leaft) && JumpPower ==Jumpminpower)
        {
            rb.velocity = new Vector3(-Speed, rb.velocity.y, 0);
            diretion = -1;
        }

        if (Input.GetKey(right) && JumpPower == Jumpminpower)
        {
            rb.velocity = new Vector3(Speed, rb.velocity.y, 0);
            diretion = 1;
        }

        // Move up
        if (jump == true)
        {
            rb.AddForce(new Vector2(JumpPower * JumpPowerX * diretion, JumpPower * JumpPowerY), ForceMode2D.Impulse);
            jump = false;
            JumpPower = Jumpminpower;
        }
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }
}


