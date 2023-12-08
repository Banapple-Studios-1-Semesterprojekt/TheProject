using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_trigger : MonoBehaviour
{
    [SerializeField] bool always_active=false;
    [SerializeField] bool dog_trigger = false;
    [SerializeField] bool cat_trigger = false;
    private Canvas canvas;
    private int players=0;
    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
        if (always_active)
        {
            players = 10;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (cat_trigger&&collision.CompareTag("Cat"))
        {
            players++;
        }
        if (dog_trigger&&collision.CompareTag("Dog"))
        {
            players++;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (!always_active)
        {
            Debug.Log(2);
            if (cat_trigger && collision.CompareTag("Cat"))
            {
                players--;
            }
            if (dog_trigger && collision.CompareTag("Dog"))
            {
                players--;
            }

        }   
    }
    private void Update()
    {
        if (players>0)
        {
            canvas.enabled = true;
        }
        else
        {
            canvas.enabled = false;
        }
    }
}
