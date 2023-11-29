using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject SetingsUI;

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
            SetingsUI.SetActive(false);
            if (isPause)
            {
                startGame();
            }
            else
            {
                GetComponent<Image>().enabled = true;
                pauseUI.SetActive(true);
                isPause = true;
                Time.timeScale = 0;
            }
        }
    }

    public void startGame()
    {
        gameObject.GetComponent<Image>().enabled = false;
        pauseUI.SetActive(false);
        isPause = false;
        Time.timeScale = 1;
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Settings()
    {
        if (SetingsUI.activeInHierarchy)
        {
            SetingsUI.SetActive(false);
            pauseUI.SetActive(true);

        }
        else
        {
            SetingsUI.SetActive(true);
            pauseUI.SetActive(false);
        }
    }

}