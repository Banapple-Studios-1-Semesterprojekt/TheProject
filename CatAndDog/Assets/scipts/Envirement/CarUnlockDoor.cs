using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUnlockDoor : MonoBehaviour
{
    public BoxCollider2D door;
    public SpriteRenderer leftDoorSpriteRenderer;

    public bool doorLocked = true;

    public void setDoorOpen()
    {
        door.enabled = false;
        if (doorLocked)
        {
            // Unlock the left door when the cat approaches it from the right side inside the car.
            doorLocked = false;
            leftDoorSpriteRenderer.color = Color.green; // Set to green (unlocked) color.
        }
    }
}