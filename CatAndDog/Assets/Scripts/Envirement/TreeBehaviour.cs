using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    public bool isCatOnBranch = false;

    public Animator treeAnimator;

    // Update is called once per frame
    void Update()
    {
        if (isCatOnBranch)
        {
            treeAnimator.SetBool("isCatOnBranch", true);
        }
        else if (!isCatOnBranch)
        {
            treeAnimator.SetBool("isCatOnBranch", false);
        }
    }
}