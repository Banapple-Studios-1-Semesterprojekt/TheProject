using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTransparency : MonoBehaviour
{
    public GameObject car; // Reference to the car object.
    public SpriteRenderer frontSpriteRenderer; // Reference to the front of the car's sprite renderer.
    public bool isCharacterInside = false; // Flag to track if the character is inside the car.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat") || other.CompareTag("Dog"))
        {
            isCharacterInside = true;
            // Adjust the transparency of the front of the car.
            Color frontColor = frontSpriteRenderer.color;
            frontColor.a = 0.5f; // Set transparency to 50%.
            frontSpriteRenderer.color = frontColor;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cat") || other.CompareTag("Dog"))
        {
            isCharacterInside = false;
            // Restore the transparency of the car's front.
            Color frontColor = frontSpriteRenderer.color;
            frontColor.a = 1.0f; // Set transparency to 100%.
            frontSpriteRenderer.color = frontColor;
        }
    }
}