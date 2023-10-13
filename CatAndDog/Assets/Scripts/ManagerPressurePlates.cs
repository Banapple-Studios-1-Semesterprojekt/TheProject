using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPressurePlates : MonoBehaviour
{
    public OpenFence openFence; //Creates a data type which is a script and references the script you drag and drop onto this script.

    public int playersOnPlate;

    public void NumberOfPlayers()
    {
        if (playersOnPlate == 2)
        {
            openFence._openFence = false;
            Debug.Log("open sesame");
        }
    }
}
