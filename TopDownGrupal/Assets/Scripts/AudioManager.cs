using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] AudioClip[] clipCollection = new AudioClip[8];
    [SerializeField] AudioClip[] musicClips;
    [SerializeField] AudioClip[] ambienceClips;
    [SerializeField] private AudioSource soundsSource;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource ambienceSource;
    private AudioClip currentMusicClip;
    private AudioClip currentAmbienceClip;


    public static AudioManager Instance { get; private set; } 

    private void Awake()
    {
        Instance = this;
        soundsSource.spatialBlend = 0f;

        musicSource.loop = true;
        musicSource.spatialBlend = 0f;
        PlayMusic(0, 0.1f);

        ambienceSource.loop = true;
        ambienceSource.spatialBlend = 0f;
        PlayAmbience(0, 0.5f);
    }

    public void PlaySFX(int clipIndex, float volume = 1f)
    {
        if (clipCollection[clipIndex] != null)
            soundsSource.PlayOneShot(clipCollection[clipIndex], volume);
    }

    public void PlayMusic(int clipIndex = 0, float volume = 0.75f, bool loops = true)
    {
        if (currentMusicClip == musicClips[clipIndex])
            return;

        musicSource.Stop();
        musicSource.clip = musicClips[clipIndex];
        currentMusicClip = musicClips[clipIndex];
        musicSource.volume = volume;
        musicSource.loop = loops;
        musicSource.Play();
    }

    public void PlayAmbience(int clipIndex = 0, float volume = 0.75f, bool loops = true)
    {
        if (currentAmbienceClip == ambienceClips[clipIndex])
            return;

        ambienceSource.Stop();
        ambienceSource.clip = ambienceClips[clipIndex];
        currentAmbienceClip = ambienceClips[clipIndex];
        ambienceSource.volume = volume;
        ambienceSource.loop = loops;
        ambienceSource.Play();
    }
}
