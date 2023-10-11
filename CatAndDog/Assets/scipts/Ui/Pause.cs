using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                gameObject.GetComponent<Image>().enabled = false;
                pauseUI.SetActive(false);
                isPause = false;
                Time.timeScale = 1;
            }
            else
            {
                gameObject.GetComponent<Image>().enabled = true;
                pauseUI.SetActive(true);
                isPause = true;
                Time.timeScale = 0;
            }
        }
    }
}