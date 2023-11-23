using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    //bagground image
    public GameObject Win_screen;

    //Intene controling of how manny stars the playeres have earned 
    private int StarCount=0;

    public static bool stopmoving=false;


    //used to set the timmer the players have to complet the level to get a star 
    [SerializeField] int TagetTime = 0;


    //Tmppro to display time
    [SerializeField] TMP_Text TimeDisplay;
    [SerializeField] TMP_Text TagetTimeDisplay;
    // Image arays of the stars and collecterbel types on the win screen
    [SerializeField] Image[] star;
    [SerializeField] Image[] bone;
    [SerializeField] Image[] Catfood;

    //sprites to be aplied to the image objects
    [SerializeField] Sprite CatFood;
    [SerializeField] Sprite CatcutOut;
    [SerializeField] Sprite Bone;
    [SerializeField] Sprite BonecutOut;
    [SerializeField] Sprite Star;
    [SerializeField] Sprite StarCutout;

    //UIController to get information to define win screen behavior 
    public UIController uiControler;

    // used to make sure you onky win ones both players have resched there goals 
    public static int playersatgoal=0;

    //used to desied witch goal is for each player
    
    private GameObject Player;
    public enum PlayerType
    { Dog, Cat }
    public PlayerType playerType;
    public string playertag;
    // Start is called before the first frame update
    void Start()
    {
        
        stopmoving=false;
        // desied witch player this goal belongs to 
        if (playerType==PlayerType.Dog)
        {
            playertag = "Dog";
        }
        else
        {
            playertag = "Cat";
        }
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if collition with corect player set players at goal to plus 1 
        // if players at goal is greater than 1 stop time an call setWinSreen
        if (collision.CompareTag(playertag))
        {
            Player = collision.gameObject;
            playersatgoal += 1;
            if (playersatgoal>1)
            {
                uiControler.stoptimer();
                Invoke("setWinScreen", 2);
                stopmoving = true;
               
            }
        }
    }
    private void Update()
    {
        //activate stopmove
        if (stopmoving == true)
        {
            Stopmove();
        }
    }
    private void Stopmove( )
    {
        //deactivate playermovement
        Player.GetComponent<Movement>().enabled = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if playe leaves the goal set Players at goal to minus 1 
        if (collision.CompareTag(playertag))
        {
            playersatgoal -= 1;


        }
    }

    private void setWinScreen()
    {
        //set win screen to active
        Win_screen.SetActive(true);

        //Make some time convertion variabels and set t_S(time in secorns) to uicontrolers timer
        int t_S= uiControler.Timer;
        int t_M=0;
        //make disblay strings
        string sec = "00";
        string min = "00";
        
        //while t_S is more than 59 set t_S to minus 60 and t_M to plus 1
        while(t_S>59)
        {
            t_S-=60;
            t_M++;
        }

        // if t_S is greater than 9 set string sec to string value of t_S else do the same but put a zero in fornt 
        if (t_S>9)
        {
            sec = t_S.ToString();
        }
        else{sec ="0" + t_S.ToString();}
        //do the same for minuts
        if (t_M > 9)
        {
            min = t_M.ToString();
        }
        else{min = "0" + t_M.ToString();}
        
        //Set time Display text to min : sec
        TimeDisplay.text = min+":"+sec;

        //do the same prosses as above for target time 
        t_S = TagetTime;
        while (t_S > 59)
        {
            t_S -= 60;
            t_M++;
        }
        if (t_S > 9)
        {
            sec = t_S.ToString();
        }
        else { sec = "0" + t_S.ToString(); }

        if (t_M > 10)
        {
            min = t_M.ToString();
        }
        else { min = "0" + t_M.ToString(); }

        TagetTimeDisplay.text = min + ":" + sec;

        // set defult Image for star vone and catfood   
        for (int i = 0; i < 2; i++)
        {
            Catfood[i].sprite = CatcutOut;
            bone[i].sprite = BonecutOut;
            star[i].sprite = StarCutout;
        }

        // for each catfood collected set one of the catfood images to the filled out image
        for (int i = 0; i < uiControler.catFood; i++)
        {
            Catfood[i].sprite = CatFood;   
        }
        // for each dogFood collected set one of the dogFood images to the filled out image
        for (int i = 0; i < uiControler.dogFood; i++)
        {
            bone[i].sprite = Bone;
        }
        // if trhee catfood and dogfood have ben collected set starcount to plus 1
        if (uiControler.catFood==3)
        {
            StarCount++;
        }
        if (uiControler.dogFood == 3)
        {
            StarCount++;
        }
        //if Timer is less than or equel to targetime set starcounter to plus 1
        if (uiControler.Timer <= TagetTime)
        {
            StarCount++;
        }

        // for each star collected set one of the star images to the filled out image
        for (int i = 0; i < StarCount; i++)
        {
            star[i].sprite = Star;
        }
    }
}
