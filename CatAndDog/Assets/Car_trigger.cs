using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car_trigger : MonoBehaviour
{
    public BoxCollider2D dore;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setdoreopen()
    {
        dore.enabled = false;
    }

}
