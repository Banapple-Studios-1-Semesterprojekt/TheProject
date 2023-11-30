using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    private AudioSource source;
    private Movement playerScript;

    private AudioClip jumpClip;
    private AudioClip barkClip;

    private void Start()
    {
        playerScript = GetComponentInParent<Movement>();
        source = GetComponent<AudioSource>();
        jumpClip = DataManager.instance.jumpClip;
        barkClip = DataManager.instance.barkClip;

        playerScript.onPlayerJump += PlayerScript_onPlayerJump;

        if(transform.parent.CompareTag("Dog"))
        {
            FindAnyObjectByType<Bark>().onBark += PlayerSounds_onBark;
        }
    }

    private void PlayerSounds_onBark()
    {
        PlaySound(barkClip);
    }

    private void PlayerScript_onPlayerJump()
    {
        PlaySound(jumpClip);
    }

    public void PlaySound(AudioClip clip)
    {
        source.pitch = Random.Range(0.8f, 1.2f);
        source.PlayOneShot(clip);
    }
}
