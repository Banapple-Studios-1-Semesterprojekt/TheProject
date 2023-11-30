using UnityEngine;

public enum GroundType { Grass, Water, Road }
public class GroundParticles : MonoBehaviour
{
    [SerializeField] private GroundType groundType;
    private ParticleSystem particlesPrefab;
    private ParticleSystem.MainModule module;

    private void Start()
    {
        particlesPrefab = DataManager.instance.groundParticles;
        module = particlesPrefab.main;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Cat") || collision.transform.CompareTag("Dog"))
        {
            SpawnGroundParticles(collision.transform);
        }
    }

    private void SpawnGroundParticles(Transform target)
    {
        GroundParticlesProperties colors = DataManager.instance.GetColors(groundType);
        ParticleSystem spawnedParticles = Instantiate(particlesPrefab, target.position + Vector3.down * 0.5f - Vector3.forward, Quaternion.Euler(-90,0,0));
        module = spawnedParticles.main;
        module.startColor = new ParticleSystem.MinMaxGradient(colors.color01, colors.color02);
        Destroy(spawnedParticles.gameObject, spawnedParticles.main.duration);
    }
}

[System.Serializable]
public class GroundParticlesProperties
{
    public Color color01;
    public Color color02;

    public GroundParticlesProperties(Color color1, Color color2)
    {
        color01 = color1;
        color02 = color2;
    }
    public GroundParticlesProperties() 
    {
        color01 = Color.white;
        color02 = Color.white;
    }
}
