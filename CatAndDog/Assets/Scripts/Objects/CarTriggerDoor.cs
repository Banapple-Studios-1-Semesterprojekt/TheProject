using UnityEngine;

public class CarTriggerDoor : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Cat")) {
            GetComponentInParent<CarUnlockDoor>().setDoorOpen();
        }
    }
}