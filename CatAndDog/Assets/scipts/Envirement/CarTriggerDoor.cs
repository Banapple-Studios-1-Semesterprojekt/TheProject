using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTriggerDoor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat"))
        {
            GetComponentInParent<CarUnlockDoor>().setDoorOpen();
        }
    }
}