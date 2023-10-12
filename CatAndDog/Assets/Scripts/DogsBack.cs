using System.Collections;
using UnityEngine;

public class DogsBack : MonoBehaviour
{
    private bool catIsOnBack = false;
    private Rigidbody2D catRB;
    private Collider2D collide;

    private void Start()
    {
        catRB = Movementcat.instance.GetRigidbody();
        collide = GetComponent<Collider2D>();
    }

    IEnumerator CheckIfCatMoves()
    {
        yield return new WaitForSeconds(0.2f);
        if(catRB.velocity.sqrMagnitude > 0.01f && catIsOnBack)
        {
            StartCoroutine(DisableBack());
            catIsOnBack = false;
        }

        if(catIsOnBack) 
        {
            StartCoroutine(CheckIfCatMoves());
        }
    }

    IEnumerator DisableBack()
    {
        collide.enabled = false;
        yield return new WaitForSeconds(1);
        collide.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("cat"))
        {
            catIsOnBack = true;
            StartCoroutine(CheckIfCatMoves());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("cat"))
        {
            catIsOnBack = false;
        }
    }
}
