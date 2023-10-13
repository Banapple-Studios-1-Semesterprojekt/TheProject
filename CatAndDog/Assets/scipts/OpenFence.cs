using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFence : MonoBehaviour
{   //Checks whether the fence is open or not.
    public bool _openFence; //Starts being false.

    Vector3 fenceOpenPosition; //Determines the position of the fence when it is open.
    Vector3 fenceClosePosition; //Determines the position of the fence when it is closed.
    float fenceSpeed = 10f; //The speed at which the fence opens.


    // Start is called before the first frame update
    void Awake()
    {
        fenceOpenPosition = transform.position; //Uses the transform of the object the script is attached to. In this case, the fence.
        fenceClosePosition = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        //A vector 3 that uses the object's transform --> position on the x, y and z axis. 
        //The y-axis' position is added with 3.
    }

    // Update is called once per frame
    void Update()
    {
        if (_openFence) //If the door is NOT open, then call the method "OpenDoor()".
        {
            OpenDoor(); 
        }
        else if (!_openFence) //If door is open, then call method "CloseDoor()".
        {
            CloseDoor();
        }

    }

    public void OpenDoor()
    {
        if(transform.position != fenceOpenPosition) 
        //If the position of the fence is NOT equal to the position when the fence is open, then change the position so it opens.
        //Checking whether the fence is at the same position or not as the condition.
        {
            transform.position = Vector3.MoveTowards(transform.position, fenceOpenPosition, fenceSpeed * Time.deltaTime); 
            //changes the position of the fence. 
            /*Uses the method "MoveTowards" which takes the original position (where is the fence right now?), 
             *new position (where do you want it?) and how fast do you want it to reach this new position(?).*/
            //Multiplying by "Time.deltaTime" to ensure the fenceSpeed is constant and based on seconds, not frames.
        }
    }

    public void CloseDoor()
    {
        if (transform.position != fenceClosePosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, fenceClosePosition, fenceSpeed * Time.deltaTime);
        }
    }

}
