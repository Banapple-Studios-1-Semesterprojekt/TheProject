using UnityEngine;

public class DataManager : MonoBehaviour
{
    #region Singleton
    public static DataManager instance;
    private void Awake()
    {
        if(instance == null) { instance = this; }
        else { Destroy(this); }
    }
    #endregion

    public ParticleSystem groundParticles;

    private const float _COLORADD = 0.5f;
    [SerializeField] private GroundParticlesProperties grassColors = new GroundParticlesProperties(Color.green, Color.green - new Color(_COLORADD, _COLORADD, _COLORADD));
    [SerializeField] private GroundParticlesProperties waterColors = new GroundParticlesProperties(Color.blue, Color.blue + new Color(_COLORADD, _COLORADD, _COLORADD));
    [SerializeField] private GroundParticlesProperties roadColors = new GroundParticlesProperties(Color.black, Color.black + new Color(_COLORADD, _COLORADD, _COLORADD));

    public GroundParticlesProperties GetColors(GroundType type)
    {
        switch(type)
        {
            case GroundType.Grass:
                return grassColors;
            case GroundType.Water:
                return waterColors;
            case GroundType.Road:
                return roadColors;
            default:
                return null;
        }
    }
}
