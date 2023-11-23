using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rat : MonoBehaviour
{
    // intern styring der styre rottens behavior
    private bool isScared=false;
    //bool der kontrolere om rotten løber tilbage til den oprinlige potion efter den er blvet skræmt
    [SerializeField] bool returntoStartpos=false;
    //intern styring af hvornår den skal løbe tilbage til startpotion 
    private bool runtostart=false;
    //potionen af hunes bark
    private float barkposition;
    // start potition
    private float startpos;
    //styre hvor lang tid der går mellem rotten skifter retning
    [SerializeField] float walkdis;
    // styre hvor lang tid rotten er bange og løber væk i
    [SerializeField] float scaredtime;
    // hvor hurtigt bevæger rotten sig
    [SerializeField] float walkspeed;
    // intern styring af retningen rotten løber væk i
    private float scaredspeed;
    private Rigidbody2D rb;
    private ParticleSystem part;

    
    
    private void Start()
    {
        //set startposition
        startpos = transform.position.x ;
        rb = GetComponent<Rigidbody2D>();
        part = GetComponent<ParticleSystem>();
        StartCoroutine(move());
    }
     IEnumerator move()
    {
        // corutine der skifter mellem at rotten går frem og tilbage og skifte retning tilsvarene
        while (isScared==false)
        {
            rb.velocity = new Vector2(walkspeed, 0);
            if (!isScared)
            {
                 transform.eulerAngles = new Vector2(0,0);
            }
           
            yield return new WaitForSeconds(walkdis);
            rb.velocity = new Vector2(-walkspeed, 0);
            if (!isScared)
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            yield return new WaitForSeconds(walkdis);
        }
    }

private void FixedUpdate()
    {
        // hvis runtostart er true og rotten ikke er tæt nok på sin startpostion så gå i modsatte retning af retningen rotten løb væk fra
        if (runtostart && Mathf.Abs(transform.position.x)-Mathf.Abs(startpos) >0.5f)
        {

            rb.velocity = new Vector2(-scaredspeed, rb.velocity.y);
        }else if (runtostart)
        {
            // hvis rotten er tæt nok på sin start potion så start corutinen move 
            runtostart = false;
            StartCoroutine(move());
        }
        // hvis isScared er true løb væk
        if (isScared)
        {
            rb.velocity = new Vector2(scaredspeed, rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*ved colistion med bark sæt isScared til true, Stop coroutinen,sæt scaredspeed til 0(for at få den til at stå stille før den begynder at løbe)
        afspil partikelsystemet(udråbstegn), chek fra hvilken retning barked kom fra og sæt retningen til den retning,lav et lille hop og invoke startscared og stopscared
        */
        //ved colition med players restart scene
        if (collision.CompareTag("Bark")&&!isScared)
        {
            barkposition = collision.transform.position.x;
            scaredspeed = 0;
            isScared = true;
            StopCoroutine(move());
            part.Play();
            if (transform.position.x < barkposition)
            {
                transform.eulerAngles = new Vector2(0, 0);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
            }
            rb.AddForce(new Vector2(0,5), ForceMode2D.Impulse);
            Invoke("Startscared", 1);
            Invoke("stopscared", scaredtime);
            
           
        }
        else if (collision.CompareTag("Cat") || collision.CompareTag("Dog"))
        {
            //hvis rotten rammer katten eller hunden reset level 
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    private void Startscared()
    {
        // chek retningen køet kom fra og roter så rotten vender væk fra den retning og sæt scaredspeed til at gå i modsatte retning af gøet 
        if (transform.position.x < barkposition)
        {
            scaredspeed = walkspeed * -1;
            transform.eulerAngles = new Vector2(0, 180);
        }
        else
        {
            scaredspeed = walkspeed;
            transform.eulerAngles = new Vector2(0, 0);
        }
    }

    //Sæt isScrared til false, hvis returntoStartpos er true sæt runtostart til true og drej 180 grader hvis ikke Start coroutinen move 
    private void stopscared()
    {
        isScared = false;
        if (returntoStartpos)
        {
            runtostart = true;
            transform.Rotate(0, 180, 0,Space.Self);
        }
        else
        {
         StartCoroutine(move());
        }
    }
}