using Unity.VisualScripting;
using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    //makes sure ther only is a certain amount of particels at any given time
    private int PopulationControler=0;
    [SerializeField] private ParticleSystem splashParticles;
    [SerializeField] private bool onlyForPlayers = false;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (onlyForPlayers && (collision.CompareTag("Cat") || collision.CompareTag("Dog")))
        {

            if (collision.GetComponent<Rigidbody2D>().velocity.x > 4 || collision.GetComponent<Rigidbody2D>().velocity.x < -4 || PopulationControler <= 1)
            {
                SpawnParticles(collision.transform.position);
                return;
            }
           
            
        }
        if(collision.GetComponent<Rigidbody2D>().velocity.x>4|| collision.GetComponent<Rigidbody2D>().velocity.x < -4|| PopulationControler <= 1) 
        {
            SpawnParticles(collision.transform.position);
        }
        
        
    }

    private void SpawnParticles(Vector3 pos)
    {


        PopulationControler++;
        ParticleSystem PS = Instantiate(splashParticles, new Vector3(pos.x, pos.y - 1.5f, -1), Quaternion.identity);
        PS.Play();
        Destroy(PS.gameObject, 1f);
        Invoke("Populationdecres", 1f);
        
        
    }

    private void Populationdecres()
    {
        PopulationControler--;
    }
}
