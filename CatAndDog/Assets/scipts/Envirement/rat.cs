using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rat : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ved colistion med bark destroy rat og ved colition med players restart scene
        if (collision.tag == "bark") {
            Destroy(gameObject);
         }
        else if (collision.tag =="cat"|| collision.tag=="dog")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}