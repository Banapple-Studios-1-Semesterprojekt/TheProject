using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementdog : MonoBehaviour
{
    public LayerMask jord;
    public LayerMask medspillerlag;
    public float raylength = 1;
    private float colidersize = 1;
    public KeyCode leaft;
    public KeyCode right;
    public KeyCode up;
    public float Speed = 1f;
    public float JumpPower = 0f;
    private bool jump = false;
    public float JumpPowerX = 0.2f;
    public float JumpPowerY = 0.8f;
    private float diretion = 1;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;

    public static Movementdog instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        colidersize = GetComponent<BoxCollider2D>().size.x;
        boxCol = GetComponent<BoxCollider2D>();
        //Get rigedbody frome gameobjekt
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(up) && isgrounded())
        {
            jump = true;
        }
    }
    //check if grounded 
    private bool isgrounded()
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
        if (Input.GetKey(leaft) && isgrounded())
        {
            rb.velocity = new Vector3(-Speed, rb.velocity.y, 0);
            diretion = -1;
        }

        if (Input.GetKey(right) && isgrounded())
        {
            rb.velocity = new Vector3(Speed, rb.velocity.y, 0);
            diretion = 1;
        }
        
        // Move up
        if (jump == true)
        {
            rb.AddForce(new Vector2(JumpPower * JumpPowerX * diretion, JumpPower * JumpPowerY), ForceMode2D.Impulse);
            jump = false;
        }
    }
}