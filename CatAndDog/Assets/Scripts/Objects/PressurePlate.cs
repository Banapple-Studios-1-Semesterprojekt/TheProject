using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private ManagerPressurePlates manager;
    private Animator animator;

    float plateDelay = 0.2f; //When can the plate be pressed again. --> Ensures the plate does not continually go up and down.
    public bool onPlate = false;
    public bool dogsPlate = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        manager = FindAnyObjectByType<ManagerPressurePlates>(); //Finds the script "ManagerPressurePlates".
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //"collision" = What is colliding with me? (The object the script is attaced to). 
      if (collision.CompareTag("Dog") && dogsPlate)
        {
            onPlate = !onPlate; //Sets "onPlate" to true.
            manager.playersOnPlate++;
            manager.NumberOfPlayers();
            animator.SetBool("PlayerOnPlate", true);
            Debug.Log("One player is on plate");
        }
     if(collision.CompareTag("Cat") && !dogsPlate)
        {
            onPlate = !onPlate; //Sets "onPlate" to true.
            manager.playersOnPlate++;
            manager.NumberOfPlayers();
            animator.SetBool("PlayerOnPlate", true);
            Debug.Log("One player is on other plate");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat") && !dogsPlate)
        {
            onPlate = false;
            if(manager.playersOnPlate <= 0)
            {
                return; 
            }
            manager.playersOnPlate--;
            animator.SetBool("PlayerOnPlate", false);
            StartCoroutine(PlateUpDelay(plateDelay));

            Debug.Log("Went off plate");
        }
        else if(collision.CompareTag("Dog") && dogsPlate)
        {
            onPlate = false;
            if (manager.playersOnPlate <= 0)
            {
                return;
            }
            manager.playersOnPlate--;
            animator.SetBool("PlayerOnPlate", false);
            StartCoroutine(PlateUpDelay(plateDelay));

            Debug.Log("Went off plate");
        }
               
    }

    IEnumerator PlateUpDelay(float timer)
    {
        yield return new WaitForSeconds(timer);
        onPlate = false;
    }


}
