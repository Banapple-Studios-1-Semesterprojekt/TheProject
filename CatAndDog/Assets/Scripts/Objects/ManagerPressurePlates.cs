using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPressurePlates : MonoBehaviour
{
    public Animator animator;

    public int playersOnPlate;


    public void NumberOfPlayers()
    {
        if (playersOnPlate == 2)
        {
            animator.SetBool("isFenceOpen", true);
            Debug.Log("open sesame");
        }
    }
}
