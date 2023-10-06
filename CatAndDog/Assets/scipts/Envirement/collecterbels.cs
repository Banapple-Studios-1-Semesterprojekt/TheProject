using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collecterbels : MonoBehaviour
{
    // 1 dogfood 2 catfood 3 both 4 unlock
    public int type=1;
    public int unlook = 1;
    private UI_controller controller;
    public Sprite tun;
    public Sprite bone;

    // Start is called before the first frame update
    void Start()
    {
        // set collecterbel image 
        if (type == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = bone;
        }else if (type == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = tun;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ved triggerenter chek type og forøg tyoe i UIcontroller med 1 og bed UIcontroller om at opdatere score text
        controller = GameObject.Find("Canvas").GetComponent<UI_controller>();
        switch (type)
        {
            case 1:
                if (other.tag == "dog")
                {
                    controller.dogfood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                    
                }

            break;
          
            case 2:
                if (other.tag == "cat")
                {
                    controller.catfood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                   
                }

                break;
            
            case 3:
                if (other.tag == "dog" || other.tag == "cat")
                {
                    controller.catfood++;
                    controller.dogfood++;
                    controller.Updatescore();
                    Destroy(gameObject);
                }
                break;
            case 4:
                if (other.tag == "dog" || other.tag == "cat")
                {
                    controller.Unlooker(unlook);
                    Destroy(gameObject);
                }
                break;


        }
    }
}
