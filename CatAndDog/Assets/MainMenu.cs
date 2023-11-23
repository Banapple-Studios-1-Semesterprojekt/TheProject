using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI volumeText;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle fullscreenToggle;

    // Initializing Options
    private void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1);
        fullscreenToggle.isOn = PlayerPrefs.GetInt("Fullscreen", 1) == 1;
    }


    // Menu Functions:

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Quitted!");
    }

    
    // Settings Function Below:

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
}
