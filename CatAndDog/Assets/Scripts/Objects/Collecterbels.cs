using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType
{ Bone, Tuna, Both, Unlock }

public class Collecterbels : MonoBehaviour
{
    // 1 dogFood 2 catFood 3 both 4 unlock
    public CollectableType cType;

    //public int type = 1;

    public int unlock = 1;
    public Sprite tuna;
    public Sprite bone;

    private UIController controller;
    private AudioSource pickUpCollectible;

    // Start is called before the first frame update
    private void Start()
    {
        pickUpCollectible = GetComponent<AudioSource>();
        // set collectable image
        if (cType == CollectableType.Bone)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bone;
        }
        else if (cType == CollectableType.Tuna)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tuna;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Dog") || other.CompareTag("Cat"))
        {
            pickUpCollectible.Play();
        }
        // ved triggerenter chek type og for�g tyoe i UIcontroller med 1 og bed UIcontroller om at opdatere score text
        controller = GameObject.Find("Canvas").GetComponent<UIController>();
        switch (cType)
        {
            case CollectableType.Bone:
                if (other.CompareTag("Dog"))
                {
                    controller.dogFood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }

                break;

            case CollectableType.Tuna:
                if (other.CompareTag("Cat"))
                {
                    controller.catFood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }

                break;

            case CollectableType.Both:
                if (other.CompareTag("Dog") || other.CompareTag("Cat"))
                {
                    controller.catFood++;
                    controller.dogFood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }
                break;

            case CollectableType.Unlock:
                if (other.CompareTag("Dog") || other.CompareTag("Cat"))
                {
                    controller.Unlocker(unlock);
                    Destroy(gameObject);
                }
                break;
        }
    }
}