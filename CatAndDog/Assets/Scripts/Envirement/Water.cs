using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private SpriteRenderer cat;

    //SerializeField gør en private variabel synlig i Unity Inspectoren
    [SerializeField] private Color originalColor;
    [SerializeField] private float pushPower = 5f;
    [SerializeField] private float disableCatTime = 1.5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            cat = other.GetComponent<SpriteRenderer>();
            StartCoroutine(PushCatBack(other.GetComponent<Rigidbody2D>()));
        }
    }

    IEnumerator PushCatBack(Rigidbody2D rb)
    {
        rb.GetComponent<Movement>().enabled = false;
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(-1, 1) * pushPower, ForceMode2D.Impulse);
        cat.color = cat.color = new Color(1, 0, 0);

        yield return new WaitForSeconds(disableCatTime);

        cat.color = originalColor;
        rb.GetComponent<Movement>().enabled = true;
    }
}