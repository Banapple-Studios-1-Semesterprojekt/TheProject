using UnityEngine;

public class TriggerCameraSpot : MonoBehaviour
{
    [SerializeField] private Transform targetSpot;
    [SerializeField] private float targetZoom = 9f;

    private bool catInside, dogInside;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat")) { catInside = true; }
        else if(collision.CompareTag("Dog")) { dogInside = true; }

        if ((collision.CompareTag("Cat") || collision.CompareTag("Dog")) && (catInside && dogInside))
        {
            CameraController.instance.SetCameraToSpot(targetSpot, targetZoom);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat")) { catInside = false; }
        else if (collision.CompareTag("Dog")) { dogInside = false; }

        if (collision.CompareTag("Cat") || collision.CompareTag("Dog"))
        {
            CameraController.instance.RemoveCameraFromSpot();
        }
    }
}
