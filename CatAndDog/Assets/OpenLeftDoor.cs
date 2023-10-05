using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLeftDoor : MonoBehaviour
{
    // This flag will track if the wall is currently locked.
    private bool isLocked = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the wall is locked and the collision comes from the right side.
        if (isLocked && other.transform.position.x > transform.position.x)
        {
            // Unlock the wall.
            isLocked = false;

            // Disable the Collider to make the wall passable.
            GetComponent<Collider2D>().enabled = false;
        }
    }
}