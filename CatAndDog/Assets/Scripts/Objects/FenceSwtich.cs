using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSwitch : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Dog"))
        {
            animator.SetBool("isFenceOpen", true);
            GeneralSoundEffect.instance.PlaySoundEffectWithRandomPitch(DataManager.instance.fenceClip, 1f);
            enabled = false;
        }       
    }
}

