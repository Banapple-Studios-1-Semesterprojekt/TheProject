using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rat : MonoBehaviour
{
    public bool Scared = false;
    public bool MoveRight = true;
    public float rundis = 1;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WaitAndPrint());
    }

    void Update()
    {
        if (MoveRight == true)
        {
        rb.velocity = new Vector2(-1, 0);
        }
        else
        {
        rb.velocity = new Vector2(1, 0);
        }
    }
    private IEnumerator WaitAndPrint( )
    {
        while (true)
        {
            
           
            yield return new WaitForSeconds(rundis);
            MoveRight = false;
            yield return new WaitForSeconds(rundis);
            MoveRight = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ved colistion med bark destroy rat og ved colition med players restart scene
        if (collision.tag == "bark") {
            Destroy(gameObject);
         }
        else if (collision.tag =="cat"|| collision.tag=="dog")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
