using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public KeyCode doBark;
    public bool canBark = false;
    public bool barkReset = false;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // ved input doBark set colider til aktiv, invoke reset bark om et sekund og afspild lyd
        if (canBark && Input.GetKeyDown(doBark) && barkReset == false)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            barkReset = true;
            Invoke("ResetBark", 1);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void ResetBark()
    {
        //set colider til indaktiv
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        barkReset = false;
    }
}