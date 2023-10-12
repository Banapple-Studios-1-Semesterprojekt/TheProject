using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    [SerializeField] private ParticleSystem splashParticles;
    [SerializeField] private bool onlyForPlayers = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onlyForPlayers && (collision.CompareTag("Cat") || collision.CompareTag("Dog")))
        {
            SpawnParticles(collision.transform.position);
            return;
        }

        SpawnParticles(collision.transform.position);
    }

    private void SpawnParticles(Vector3 pos)
    {
        ParticleSystem PS = Instantiate(splashParticles, new Vector3(pos.x, pos.y, -1), Quaternion.identity);
        PS.Play();
        Destroy(PS.gameObject, 2f);
    }
}
