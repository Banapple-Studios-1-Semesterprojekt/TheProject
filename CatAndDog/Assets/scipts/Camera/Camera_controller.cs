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
    // Start is called before the first frame update
    void Start()
    {
        cameraa = gameObject.GetComponent<Camera>();
        cameraa.orthographicSize = statzome;
        camup = statzome-5;
    }

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.position = new Vector3 ((Players[0].position.x + Players[1].position.x)/2 ,camup,-10);

        if(Mathf.Abs(Players[0].position.x - Players[1].position.x) > disbeforezome)
        {
            cameraa.orthographicSize = ((Mathf.Abs(Players[0].position.x - Players[1].position.x)- disbeforezome) *.28f+ statzome);
            camup = (Mathf.Abs(Players[0].position.x - Players[1].position.x) - disbeforezome) *.28f+ statzome - 5;
        }


    }
}
