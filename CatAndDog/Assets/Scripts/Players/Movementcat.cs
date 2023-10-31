using UnityEngine;

public class MovementCat : MonoBehaviour
{
    public LayerMask ground;
    public LayerMask coPlayerLayer;
    public float rayLength = 1;

    public KeyCode left;
    public KeyCode right;
    public KeyCode up;

    public float speed = 1f;
    public float jumpPower = 0f;
    public float jumpMaxPower = 1f;
    public float jumpMinPower = 1f;
    public float jumpBuildUpSpeed = 1f;
    public float jumpPowerX = 0.2f;
    public float jumpPowerY = 0.8f;

    private float colliderSize = 1;
    private bool jump = false;
    private float direction = 1;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;

    public static MovementCat instance;

    private void Awake()
    {
        instance = this;

        //Get rigedbody from gameobjekt
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        jumpPower = jumpMinPower;
        colliderSize = gameObject.GetComponent<BoxCollider2D>().size.x;
        //Get rigedbody frome gameobjekt
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //jump input
        if (Input.GetKey(up) && IsGrounded() && jumpPower < jumpMaxPower)
        {
            jumpPower += jumpBuildUpSpeed * Time.deltaTime;
        }
        if (Input.GetKeyUp(up) && IsGrounded())
        {
            jump = true;
        }
    }

    //check if grounded
    public bool IsGrounded()
    {
        Vector3 rayPoint = transform.position + Vector3.down * boxCol.bounds.extents.y;
        Vector2 boxSize = new Vector2(boxCol.bounds.extents.x * 2, 0.3f);
        Collider2D hit2D = Physics2D.OverlapBox(rayPoint, boxSize, 0, ground);

        return hit2D != null;
    }


    private void FixedUpdate()
    {
        //movement left right
        if (Input.GetKey(left) && jumpPower == jumpMinPower)
        {
            rb.velocity = new Vector3(-speed, rb.velocity.y, 0);
            direction = -1;
        }

        if (Input.GetKey(right) && jumpPower == jumpMinPower)
        {
            rb.velocity = new Vector3(speed, rb.velocity.y, 0);
            direction = 1;
        }

        // Move up
        if (jump == true)
        {
            rb.AddForce(new Vector2(jumpPower * jumpPowerX * direction, jumpPower * jumpPowerY), ForceMode2D.Impulse);
            jump = false;
            jumpPower = jumpMinPower;
        }
    }

    public Rigidbody2D GetRigidbody()
    {
        return rb;
    }
}