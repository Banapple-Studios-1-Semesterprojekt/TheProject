using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    //Timer Variabels 
    public int Timer=0;
    private bool time=true;
    public TMP_Text Timer_Text;


    //collecterbel Variabels
    public int catFood = 0;
    public int dogFood = 0;
    public TMP_Text catFoodScore;
    public TMP_Text dogFoodScore;
    [SerializeField] GameObject CatFoodScore;
    [SerializeField] GameObject DogFoodScore;
    public float scoretimercat = 0;
    public float scoretimerdog = 0;


    // Unlock Variabels 
    public GameObject UnlockerScren;
    public TMP_Text Unlocke_Titel;
    public TMP_Text Unlocke_Text;
    public Image Unlocke_Image;
    [SerializeField] Sprite[] Unlocke_icon;
    [SerializeField] string[] Unlocke_text;
    private Bark bark;

    private RectTransform dogScoreRect;
    [SerializeField] private Animator foodScoreAni;

    private void Start()
    {
        //find Bark and start timer
        bark = FindAnyObjectByType<Bark>();
        StartCoroutine(timer());

        dogScoreRect = DogFoodScore.GetComponent<RectTransform>();
    }

    private void Update()
    {
        /*
        //if the svoretimer is bigger than one move ther svore text into view and decreas scoretime, else make sure the score text is out of frame
        if (scoretimercat >= 0)
        {
            if (CatFoodScore.transform.localPosition.x > 1190)
            {
            CatFoodScore.transform.localPosition = new Vector2(-10+CatFoodScore.transform.localPosition.x, CatFoodScore.transform.localPosition.y);
            }
            scoretimercat -=1*Time.deltaTime;
        }
        else
        {
            if (CatFoodScore.transform.localPosition.x < 860)
            {
             CatFoodScore.transform.localPosition = new Vector2(10 + CatFoodScore.transform.localPosition.x, CatFoodScore.transform.localPosition.y);
            }
        }

        if (scoretimerdog >= 0)
        {
            if (dogScoreRect.anchoredPosition.x <= 860)
            {
                dogScoreRect.anchoredPosition = new Vector2(10 + dogScoreRect.anchoredPosition.x, DogFoodScore.transform.position.y);
                Debug.Log("Move your ass!");
            }
        }
        else
        {
            if (dogScoreRect.anchoredPosition.x > 1190)
            {
                dogScoreRect.anchoredPosition = new Vector2(-10 + dogScoreRect.anchoredPosition.x, DogFoodScore.transform.localPosition.y);
                Debug.Log("Move your ass back!");
            }
            
            scoretimerdog -= 1 * Time.deltaTime;
        }

        Debug.Log(dogScoreRect.anchoredPosition.x);
        */
    }

    public void ShowFoodScoreUI()
    {
        foodScoreAni.SetTrigger("Unlock");
    }
    public void stoptimer()
    {
        //stop timer
        StopCoroutine(timer());
        time = false;
    }
    IEnumerator timer()
    {
        //count the timer up format it to the timer in the corner 
        int sec = 0;
        int min = 0;
        string minstring=null;
        while (time)
        {
           yield return new WaitForSeconds(1);
           Timer++;
            sec++;
            if (sec==60)
            {
                min++;
                sec -= 60;
            }
            if (min<10)
            {
                minstring = "0"+min.ToString();
            }
            else
            {
                minstring = min.ToString();
            }

            if (sec<10)
            {
                Timer_Text.SetText(minstring + ":"+"0"+sec.ToString());
            }
            else
            {
               Timer_Text.SetText(minstring+":"+sec.ToString()); 
            }
            
            
        }
        

    }
    public void Updatescore()
    {
        //set scorer text to score
        catFoodScore.SetText("x " + catFood.ToString());
        dogFoodScore.SetText("x " + dogFood.ToString());
    }

    public void Unlocker(int unlock)
    {
        // Switch case to controle unlock
        switch (unlock)
        {
            case 1:
                bark.canBark = true;
                Unlocke_Text.text = Unlocke_text[0];
                Unlocke_Titel.text = Unlocke_text[1];
                Unlocke_Image.sprite = Unlocke_icon[0];
                StartCoroutine(ULScrenn());
                break;
        }
    }



    IEnumerator ULScrenn()
    {
        // unlock scenn anymation controle
        UnlockerScren.SetActive(true);

        yield return new WaitForSeconds(5);

        UnlockerScren.SetActive(false);
        StopCoroutine(ULScrenn());
    }
}
