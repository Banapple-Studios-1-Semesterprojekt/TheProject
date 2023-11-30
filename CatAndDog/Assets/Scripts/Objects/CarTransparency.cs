using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarTransparency : MonoBehaviour {
    public GameObject car; // Reference to the car object.
    public SpriteRenderer frontSpriteRenderer; // Reference to the front of the car's sprite renderer.
    public bool isCharacterInside = false; // Flag to track if the character is inside the car.
    public bool catInCar = false;
    public bool dogInCar = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Cat") || other.CompareTag("Dog")) {
            if (other.CompareTag("Cat")) {
                catInCar = true;
            }
            if (other.CompareTag("Dog")) {
                dogInCar = true;
            }
            isCharacterInside = true;
            // Adjust the transparency of the front of the car.
            Color frontColor = frontSpriteRenderer.color;
            frontColor.a = 0.01f; // Set transparency to 1%.
            frontSpriteRenderer.color = frontColor;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Cat")) {
            catInCar = false;
        }
        if (other.CompareTag("Dog")) {
            dogInCar = false;
        }
        if (!catInCar && !dogInCar) {
            isCharacterInside = false;
            // Restore the transparency of the car's front.
            Color frontColor = frontSpriteRenderer.color;
            frontColor.a = 1.0f; // Set transparency to 100%.
            frontSpriteRenderer.color = frontColor;
        }
    }
}