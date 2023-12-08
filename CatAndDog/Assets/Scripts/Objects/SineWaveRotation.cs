using UnityEngine;

public class SineWaveRotation : MonoBehaviour
{
    float sine;
    [SerializeField] private float sineStrength = 1f;
    [SerializeField] private float sineFrequency = 1f;

    private Quaternion initialRot;

    private float randomStartTime;

    private void Start()
    {
        initialRot = transform.localRotation;
        randomStartTime = Random.Range(0, 20);
    }

    private void Update()
    {
        sine = Mathf.Sin(Time.time * sineFrequency + randomStartTime) * sineStrength;

        transform.localRotation = Quaternion.Euler(0, 0, initialRot.z + sine);
    }
}
