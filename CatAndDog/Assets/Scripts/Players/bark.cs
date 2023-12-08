using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public KeyCode doBark;
    public bool canBark = false;
    public bool barkReset = false;

    public delegate void BarkAction();
    public event BarkAction onBark;

    private void LateUpdate()
    {
        // ved input doBark set colider til aktiv, invoke reset bark om et sekund og afspild lyd
        if (canBark && Input.GetKeyDown(doBark) && barkReset == false)
        {
            //event call
            onBark?.Invoke();

            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            barkReset = true;

            Invoke("ResetBark", 1);
        }
    }

    public void ResetBark()
    {
        //set colider til indaktiv
        gameObject.GetComponent<CircleCollider2D>().enabled = false;

        barkReset = false;
    }
}