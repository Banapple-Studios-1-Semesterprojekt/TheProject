using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    private ManagerPressurePlates manager;
    public OpenFence openFence;

    //public bool isFenceOpen;
    //public bool isFenceClosed;
    

    float plateY; //Moves plate on the y-axis, so it moves into the ground when pressed. 
    Vector3 plateUpPosition; //Position of plate when the plate is NOT pressed. 
    Vector3 plateDownPosition; //Position of plate when plate is pressed.
    float plateSpeed = 1f; //Speed of the movement of the plate.
    float plateDelay = 0.2f; //When can the plate be pressed again. --> Ensures the plate does not continually go up and down.
    public bool onPlate = false;
    public bool dogsPlate = false;

    private void Awake()
    {
        manager = FindAnyObjectByType<ManagerPressurePlates>(); //Finds the script "ManagerPressurePlates".

        plateY = transform.localScale.y / 2; //Divides the local scale of the pressure plate by 2. --> How much it will lower.

        plateUpPosition = transform.position; //The current position of the plate.
        plateDownPosition = new Vector3(transform.position.x, transform.position.y - plateY, transform.position.z);
        //Sets the new transform of the pressure plate. Subtracts "plateY". 
    }

    private void Update()
    {
        if (onPlate)
        {
            PlateUp();
        }
        else if (!onPlate)
        {
            PlateDown();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   //"collision" = What is colliding with me? (The object the script is attaced to). 
      if (collision.CompareTag("dog") && dogsPlate)
        {
            onPlate = !onPlate; //Sets "onPlate" to true.
            PlateDown();
            manager.playersOnPlate++;
            manager.NumberOfPlayers();
            Debug.Log("One player is on plate");
        }
     if(collision.CompareTag("Cat") && !dogsPlate)
        {
            onPlate = !onPlate; //Sets "onPlate" to true.
            PlateDown();
            manager.playersOnPlate++;
            manager.NumberOfPlayers();
            Debug.Log("One player is on plate");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cat") || collision.CompareTag("dog"))
        {
            onPlate = false;
            PlateUp();
            if(manager.playersOnPlate <= 0)
            {
                return; 
            }
            manager.playersOnPlate--;
            StartCoroutine(PlateUpDelay(plateDelay));

            Debug.Log("Went off plate");
        }
               
    }

    IEnumerator PlateUpDelay(float timer)
    {
        yield return new WaitForSeconds(timer);
        onPlate = false;
    }

    void PlateUp()
    {
        if (transform.position != plateUpPosition)
        {
            transform.position = transform.position = Vector3.MoveTowards(transform.position, plateUpPosition, plateSpeed * Time.deltaTime);
        }
        
    }

   void PlateDown()
    {
        if (transform.position == plateUpPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, plateDownPosition, plateSpeed * Time.deltaTime);
        }
    } 



}
