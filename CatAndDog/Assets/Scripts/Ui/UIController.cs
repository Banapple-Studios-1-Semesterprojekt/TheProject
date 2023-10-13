using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public int catFood = 0;
    public int dogFood = 0;
    public TMP_Text catFoodScore;
    public TMP_Text dogFoodScore;
    public Bark bark;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void Updatescore()
    {
        //set scorer text to score
        catFoodScore.SetText("x " + catFood.ToString());
        dogFoodScore.SetText("x " + dogFood.ToString());
    }

    public void Unlocker(int unlock)
    {
        switch (unlock)
        {
            case 1:
                bark.canBark = true;
                break;
        }
    }
}