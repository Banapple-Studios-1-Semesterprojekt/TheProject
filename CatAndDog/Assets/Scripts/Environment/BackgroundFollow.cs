using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    private Camera mainCam;
    private Transform trans;
    [SerializeField] private float desiredScale = 2.4f;
    private float cameraStartSize;

    private void Start()
    {
        mainCam = Camera.main;
        trans = transform;
        cameraStartSize = mainCam.GetComponent<CameraController>().startZoom;
    }

    private void LateUpdate()
    {
        trans.localScale = Vector3.one * (mainCam.orthographicSize - cameraStartSize + desiredScale);
    }
}
