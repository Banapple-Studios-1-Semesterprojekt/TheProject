using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    public GameObject car; // Reference to the car object.
    public SpriteRenderer frontSpriteRenderer; // Reference to the front of the car's sprite renderer.
    public SpriteRenderer leftDoorSpriteRenderer; // Reference to the left door's sprite renderer.
    public SpriteRenderer rightDoorSpriteRenderer; // Reference to the right door's sprite renderer.

    private bool isCharacterInside = false; // Flag to track if the character is inside the car.
    private bool isLeftDoorLocked = true;   // Flag to track if the left door is locked.

    private void Update()
    {
        // Check if the cat is inside the car before unlocking the left door.
        if (isCharacterInside && isLeftDoorLocked)
        {
            // Unlock the left door when the cat approaches it from the right side inside the car.
            isLeftDoorLocked = false;
            leftDoorSpriteRenderer.color = Color.green; // Set to green (unlocked) color.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cat"))
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
        if (other.CompareTag("Cat"))
        {
            isCharacterInside = false;
            // Restore the transparency of the car's front.
            Color frontColor = frontSpriteRenderer.color;
            frontColor.a = 1.0f; // Set transparency to 100%.
            frontSpriteRenderer.color = frontColor;
        }
    }
}