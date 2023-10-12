using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;

    private bool isPause = false;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                startGame();
            }
            else
            { 
                GetComponent<Image>().enabled = true;
                PauseUI.SetActive(true);
                isPause = true;
                Time.timeScale = 0;
            }
        }
    }
    public void startGame()
    {
     gameObject.GetComponent<Image>().enabled = false;
     PauseUI.SetActive(false);
     isPause = false;
     Time.timeScale = 1;
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}