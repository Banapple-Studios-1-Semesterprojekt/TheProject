using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_controller : MonoBehaviour
{
    public int catfood = 0;
    public int dogfood = 0;
    public TMP_Text catfoodscore;
    public TMP_Text dogfoodscore;
    public bark bark;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    public void Updatescore()
    {
        //set scorer text to score
        catfoodscore.SetText("x " + catfood.ToString());
        dogfoodscore.SetText("x " + dogfood.ToString());
    }

    public void Unlooker(int unlook)
    {
        switch (unlook)
        {
            case 1:
                bark.canbark= true;
                break;
        }
    }

}
