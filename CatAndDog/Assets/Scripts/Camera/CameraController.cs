using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] Players;
    public float startZoom = 5; // Unsure if this was what it was meaning
    public float distanceBeforeZoom = 16; // Unsure about this one too
    public float height = 5;

    public float smoothTime = 10f;
    public float spotSmoothTime = 3f;

    private Camera cameraa;
    private float camUp = 0;

    private bool isOnSpot = false;

    public static CameraController instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        cameraa = GetComponent<Camera>();
        cameraa.orthographicSize = startZoom;
        camUp = startZoom - height;
    }

    private void Update()
    {
        UpdateCameraMovement();
    }

    private void UpdateCameraMovement()
    {
        if(isOnSpot) { return; }

        Vector3 desiredPos = new Vector3((Players[0].position.x + Players[1].position.x) / 2, camUp, -10);
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothTime * Time.deltaTime);

        if (Mathf.Abs(Players[0].position.x - Players[1].position.x) > distanceBeforeZoom)
        {
            float desiredSize = ((Mathf.Abs(Players[0].position.x - Players[1].position.x) - distanceBeforeZoom) * .28f + startZoom);
            cameraa.orthographicSize = Mathf.Lerp(cameraa.orthographicSize, desiredSize, smoothTime * Time.deltaTime);
            camUp = (Mathf.Abs(Players[0].position.x - Players[1].position.x) - distanceBeforeZoom) * .28f + startZoom - height;
        }
        else
        {
            float desiredSize = ((Mathf.Abs(Players[0].position.x - Players[1].position.x) - distanceBeforeZoom) * .28f + startZoom);
            cameraa.orthographicSize = startZoom;
            camUp = startZoom - height;
        }
    }

    public void SetCameraToSpot(Transform spot, float targetZoom)
    {
        isOnSpot = true;
        StopAllCoroutines();
        StartCoroutine(SetCameraToSpotSmoothly(spot, targetZoom));
    }

    public void RemoveCameraFromSpot()
    {
        StopAllCoroutines();
        isOnSpot = false;
    }

    IEnumerator SetCameraToSpotSmoothly(Transform spot, float targetZoom)
    {
        Vector3 correctPos = new Vector3(spot.position.x, spot.position.y, transform.position.z);

        while(Vector3.Distance(transform.position, correctPos) > 0.01f && Mathf.Abs(cameraa.orthographicSize - targetZoom) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, correctPos, spotSmoothTime * Time.deltaTime);
            cameraa.orthographicSize = Mathf.Lerp(cameraa.orthographicSize, targetZoom, spotSmoothTime * Time.deltaTime);
            yield return null;
        }

        transform.position = correctPos;
        cameraa.orthographicSize = targetZoom;
    }
}