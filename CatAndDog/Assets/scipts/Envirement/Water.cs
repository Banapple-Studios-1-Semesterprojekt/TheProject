using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public SpriteRenderer cat;

    public Color originalColor;

    // Start is called before the first frame update
    private void Start()
    {
        Color originalColor = cat.color;
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            cat.color = new Color(1, 0, 0, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
        {
            cat.color = originalColor;
        }
    }
}