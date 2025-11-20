using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip musicClip;

    [Range(0f,1f)] public float musicVolume = 1f;
    [Range(0f, 1f)] public float sfxVolume = 1f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        InitializeAudioManager();
    }

    private void InitializeAudioManager()
    {
        if (musicSource)
        {
            musicSource.volume = musicVolume;
        }
        if (sfxSource)
        {
            sfxSource.volume = sfxVolume;
        }
        Debug.Log("Audio Initialized");
    }

    public void PlayMusic(AudioSource music)
    {
        if (musicSource == null) return;
        music.Play();
    }

    public void PlayMusicClip(AudioClip c)
    {
        if (!musicSource || c == null)
        {
            return;
        }
        musicSource.clip = c;
        musicSource.loop = true;
        musicSource.volume = musicVolume;
        musicSource.Play();
        Debug.Log("Now playing music");
    }

    public void StopMusic(AudioClip c) 
    {
        if (musicSource) musicSource.Stop();    
    }

    public void PlaySFX(AudioClip c)
    {
        if (!sfxSource || c == null) return;

        sfxSource.PlayOneShot(c, sfxVolume);
    }





}
