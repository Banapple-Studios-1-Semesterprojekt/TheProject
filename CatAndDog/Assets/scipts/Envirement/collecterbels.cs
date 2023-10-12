using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType { Bone, Tuna, Both, Unlock }
public class collecterbels : MonoBehaviour
{
    // 1 dogfood 2 catfood 3 both 4 unlock
    public CollectableType cType;
    //public int type=1;
    public int unlook = 1;
    private UI_controller controller;
    public Sprite tun;
    public Sprite bone;

    // Start is called before the first frame update
    void Start()
    {
        // set collecterbel image 
        if (cType == CollectableType.Bone)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bone;
        }else if (cType == CollectableType.Tuna)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tun;
        }
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ved triggerenter chek type og forøg tyoe i UIcontroller med 1 og bed UIcontroller om at opdatere score text
        controller = GameObject.Find("Canvas").GetComponent<UI_controller>();
        switch (cType)
        {
            case CollectableType.Bone:
                if (other.tag == "dog")
                {
                    controller.dogfood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                    
                }

            break;
          
            case CollectableType.Tuna:
                if (other.tag == "cat")
                {
                    controller.catfood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                   
                }

                break;
            
            case CollectableType.Both:
                if (other.tag == "dog" || other.tag == "cat")
                {
                    controller.catfood++;
                    controller.dogfood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }
                break;
            case CollectableType.Unlock:
                if (other.tag == "dog" || other.tag == "cat")
                {
                    controller.Unlooker(unlook);
                    Destroy(gameObject);
                }
                break;


        }
    }
}
