using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private SpriteRenderer cat;
    public Color originalColor = Color.white;
    [SerializeField] private float forcePower = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            if(cat == null)
            {
                cat = other.GetComponent<SpriteRenderer>();
            }
            StartCoroutine(PushCatBack(other.GetComponent<Movement>()));
        }
    }

    IEnumerator PushCatBack(Movement movement)
    {
        movement.enabled = false;
        movement.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        movement.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 1) * forcePower, ForceMode2D.Impulse);
        cat.color = new Color(1, 0, 0);

        yield return new WaitForSeconds(1.5f);

        cat.color = originalColor;
        movement.enabled = true;
    }
}