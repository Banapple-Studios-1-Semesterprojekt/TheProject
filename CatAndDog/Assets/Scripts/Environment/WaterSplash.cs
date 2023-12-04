using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    //makes sure ther only is a certain amount of particels at any given time
    private int PopulationControler=0;
    [SerializeField] private ParticleSystem splashParticles;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.GetComponent<Rigidbody2D>())
        {
            if (collision.GetComponent<Rigidbody2D>().velocity.x > 2 || collision.GetComponent<Rigidbody2D>().velocity.x < -2 || PopulationControler <= 1)
            {
                SpawnParticles(collision.transform.position);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Cat"))
        {
            SpawnParticles(collision.transform.position);
        }

        if(collision.CompareTag("Cat") || collision.CompareTag("Dog"))
        {
            GeneralSoundEffect.instance.PlaySoundEffectWithRandomPitch(DataManager.instance.waterSplash, 1f);
        }
    }

    private void SpawnParticles(Vector3 pos)
    {
        PopulationControler++;
        ParticleSystem PS = Instantiate(splashParticles, new Vector3(pos.x, pos.y - 1.5f, 0), Quaternion.Euler(-90, 0, 0));
        PS.Play();
        Destroy(PS.gameObject, 1f);
        Invoke("Populationdecres", 1f);   
    }

    private void Populationdecres()
    {
        PopulationControler--;
    }
}
