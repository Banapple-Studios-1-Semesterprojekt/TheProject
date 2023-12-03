using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPressurePlates : MonoBehaviour
{
    public Animator animator;

    public int playersOnPlate;

    private bool isOpen = false;

    public void NumberOfPlayers()
    {
        if (playersOnPlate == 2 && isOpen == false)
        {
            animator.SetBool("isFenceOpen", true);
            GeneralSoundEffect.instance.PlaySoundEffectWithRandomPitch(DataManager.instance.fenceClip, 1f);
            isOpen = true;
            Debug.Log("open sesame");
        }
    }
}
