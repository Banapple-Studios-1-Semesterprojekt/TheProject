using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ButtonSoundManager : MonoBehaviour
{
    public AudioClip mouseOverClip;
    public AudioClip mouseExitClip;
    public AudioClip mouseDownClip;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        source.pitch = Random.Range(0.975f, 1.075f);
        source.PlayOneShot(clip);
    }
}
