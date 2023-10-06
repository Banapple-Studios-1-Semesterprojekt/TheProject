using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controller : MonoBehaviour
{
    public Transform[] Players;
    private Camera cameraa;
    private float camup=0;
    public float statzome=5;
    public float disbeforezome = 16;
    public float height = 5;

    public float smoothTime = 10f;
    // Start is called before the first frame update
    void Start()
    {
        cameraa = gameObject.GetComponent<Camera>();
        cameraa.orthographicSize = statzome;
        camup = statzome- height;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredPos = new Vector3((Players[0].position.x + Players[1].position.x) / 2, camup, -10);
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothTime * Time.deltaTime);

        if(Mathf.Abs(Players[0].position.x - Players[1].position.x) > disbeforezome)
        {
            float desiredSize = ((Mathf.Abs(Players[0].position.x - Players[1].position.x) - disbeforezome) * .28f + statzome);
            cameraa.orthographicSize = Mathf.Lerp(cameraa.orthographicSize, desiredSize, smoothTime * Time.deltaTime);
            camup = (Mathf.Abs(Players[0].position.x - Players[1].position.x) - disbeforezome) *.28f+ statzome - height;
        }


    }
}
