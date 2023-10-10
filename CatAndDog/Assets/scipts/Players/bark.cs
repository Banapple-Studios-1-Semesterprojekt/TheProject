using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bark : MonoBehaviour
{
    public KeyCode dobark;
    public bool canbark = false;
    public bool barkreset = false;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // ved input dobark set colider til aktiv, invoke reset bark om et sekund og afspild lyd
        if (canbark && Input.GetKeyDown(dobark) && barkreset == false)
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = true;
            barkreset = true;
            Invoke("resetbark", 1);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

    public void resetbark()
    {
        //set colider til indaktiv
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        barkreset = false;
    }
}