using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_open_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerStay2D(Collider2D collision)
    {
       GetComponentInParent<Car_trigger>().setdoreopen();
    }
}
