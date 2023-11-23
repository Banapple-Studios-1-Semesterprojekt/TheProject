using UnityEngine;

public class TreeBehaviour : MonoBehaviour
{
    [SerializeField] private Animator treeAnimator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cat"))
        {
            treeAnimator.SetBool("catON", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Cat"))
        {
            treeAnimator.SetBool("catON", false);
        }
    }
}