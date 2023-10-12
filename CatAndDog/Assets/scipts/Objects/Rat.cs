using UnityEngine;
using UnityEngine.SceneManagement;

public class Rat : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //ved colistion med bark destroy rat og ved colition med players restart scene
        if (collision.CompareTag("Bark"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Cat") || collision.CompareTag("Dog"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}