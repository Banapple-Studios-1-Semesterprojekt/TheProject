using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] Players;
    public float startZoom = 5; // Unsure if this was what it was meaning
    public float distanceBeforeZoom = 16; // Unsure about this one too
    public float height = 5;

    public float smoothTime = 10f;

    private Camera cameraa;
    private float camUp = 0;

    // Start is called before the first frame update
    private void Start()
    {
        cameraa = gameObject.GetComponent<Camera>();
        cameraa.orthographicSize = startZoom;
        camUp = startZoom - height;
    }

    // Update is called once per frame
    private void Update()
    {
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
}