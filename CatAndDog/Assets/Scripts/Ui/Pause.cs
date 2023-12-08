using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject SetingsUI;

    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle fullscreenToggle;

    private bool isPause = false;

    // Start is called before the first frame update
    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
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

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeText.text = "Volume: " + (volume * 100).ToString("0") + "%";
        PlayerPrefs.SetFloat("Volume", volume);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("Fullscreen", isFullscreen ? 1 : 0);
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