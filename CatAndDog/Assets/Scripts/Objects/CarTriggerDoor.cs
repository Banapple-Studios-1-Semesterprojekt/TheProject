using UnityEngine;

public class CarTriggerDoor : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Cat")) {
            GetComponentInParent<CarUnlockDoor>().setDoorOpen();
            GeneralSoundEffect.instance.PlaySoundEffect(DataManager.instance.carDoorClip, 1f);
            Destroy(this);
        }
    }
}