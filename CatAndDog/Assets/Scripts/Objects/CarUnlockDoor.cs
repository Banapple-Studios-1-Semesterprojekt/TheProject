using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarUnlockDoor : MonoBehaviour {
    public BoxCollider2D door;
    public SpriteRenderer bothDoorsOpen;
    public SpriteRenderer rightDoor;
    //public GameObject car;
    //   public SpriteRenderer leftDoorSpriteRenderer;

    public bool doorLocked = true;

    public void setDoorOpen() {
        if (doorLocked) {
            // Unlock the left door when the cat approaches it from the right side inside the car.
            doorLocked = false;
            Destroy(door);
            bothDoorsOpen.enabled = true;
            rightDoor.enabled = false;
        }
    }
}