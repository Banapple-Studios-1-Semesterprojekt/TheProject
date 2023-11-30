using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat") || collision.CompareTag("Dog"))
        {
            collision.GetComponent<Death>().Setrespawn();
        }
    }

}
