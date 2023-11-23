using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBox : MonoBehaviour
{
    Rigidbody2D rb;
    public float pushPower = 3;
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Dog")
        {
            Debug.Log("Hello");
            rb = GetComponent<Rigidbody2D>();

            if (gameObject.transform.position.y > collision.gameObject.transform.position.y)
            {
                if (gameObject.transform.position.x < collision.gameObject.transform.position.x)
                {
                    rb.velocity = new Vector2(-pushPower, 0);
                }
                else
                {
                    rb.velocity = new Vector2(pushPower, 0);
                }
            }
                     
           
        }
    }




}
