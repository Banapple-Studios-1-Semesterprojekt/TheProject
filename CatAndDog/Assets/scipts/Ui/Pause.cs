using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
                gameObject.GetComponent<Image>().enabled = false;
                Pause_UI.SetActive(false);
                isPause = false;
                Time.timeScale = 1;
            }
            else
            {
                gameObject.GetComponent<Image>().enabled = true;
                Pause_UI.SetActive(true);
                isPause = true;
                Time.timeScale = 0;
            }
        }
    }
}
