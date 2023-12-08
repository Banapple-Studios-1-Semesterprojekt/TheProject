using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class GeneralSoundEffect : MonoBehaviour
{
    private AudioSource source;
    private AudioSource bgMusicSource;

    public static GeneralSoundEffect instance;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        bgMusicSource = GameObject.Find("BG Music").GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip clip, float volume)
    {
        source.pitch = 1f;
        source.volume = volume;
        source.PlayOneShot(clip);
    }
    public void PlaySoundEffectWithRandomPitch(AudioClip clip, float volume)
    {
        source.pitch = Random.Range(0.9f, 1.1f);
        source.volume = volume;
        source.PlayOneShot(clip);
    }

    public void SetBackgroundMusic(AudioClip clip, float volume, bool loop)
    {
        bgMusicSource.volume = volume;
        bgMusicSource.clip = clip;
        bgMusicSource.loop = loop;
        bgMusicSource.Play();
    }
}
