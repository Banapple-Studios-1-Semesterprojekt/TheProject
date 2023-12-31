using System.Collections;
using UnityEngine;

public class DogsBack : MonoBehaviour
{
    private bool catIsOnBack = false;
    private Rigidbody2D catRB;
    private Collider2D collide;

    private void Start()
    {
        catRB = GameObject.FindGameObjectWithTag("Cat").GetComponent<Rigidbody2D>();
        collide = GetComponent<Collider2D>();
    }

    private IEnumerator CheckIfCatMoves()
    {
        yield return new WaitForSeconds(0.2f);
        if (catRB.velocity.sqrMagnitude > 0.01f && catIsOnBack)
        {
            StartCoroutine(DisableBack());
            catIsOnBack = false;
        }

        if (catIsOnBack)
        {
            StartCoroutine(CheckIfCatMoves());
        }
    }

    private IEnumerator DisableBack()
    {
        collide.enabled = false;
        yield return new WaitForSeconds(1);
        collide.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Cat"))
        {
            catIsOnBack = true;
            //StartCoroutine(CheckIfCatMoves());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Cat"))
        {
            catIsOnBack = false;
        }
    }
}