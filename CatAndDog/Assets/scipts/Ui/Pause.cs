using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    private bool isPause=false;
    public GameObject Pause_UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                startgame();
            }
            else
            {
                
                GetComponent<Image>().enabled = true;
                Pause_UI.SetActive(true);
                isPause = true;
                Time.timeScale = 0;
            }
        }
    }
    public void startgame()
    {
     gameObject.GetComponent<Image>().enabled = false;
     Pause_UI.SetActive(false);
     isPause = false;
     Time.timeScale = 1;
    }

    public void restart_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
