﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    public List<AudioClip> MusicClips { get { return musicClips; } }

    [SerializeField] private AudioSource playerAudioSource;
    [FormerlySerializedAs("audioClips")]
    [SerializeField] private List<AudioClip> musicClips = new List<AudioClip>();
    [SerializeField] private List<AudioClip> angrySounds = new List<AudioClip>();
    [SerializeField] private List<AudioClip> pleasedSounds = new List<AudioClip>();
    [SerializeField] private List<AudioClip> thinkingSounds = new List<AudioClip>();
    [SerializeField] private List<AudioClip> windUpSounds = new List<AudioClip>();

    private void Update()
    {
        if (!playerAudioSource.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                PlayAngrySoundClip();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PlayPleasedSoundClip();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                PlayThinkingSoundClip();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                PlayWindUpSoundClip();
            }
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public void PlayAngrySoundClip()
    {
        playerAudioSource.PlayOneShot(angrySounds[Random.Range(0, angrySounds.Count)]);
    }

    public void PlayPleasedSoundClip()
    {
        playerAudioSource.PlayOneShot(pleasedSounds[Random.Range(0, pleasedSounds.Count)]);
    }

    public void PlayThinkingSoundClip()
    {
        playerAudioSource.PlayOneShot(thinkingSounds[Random.Range(0, thinkingSounds.Count)]);
    }

    public void PlayWindUpSoundClip()
    {
        playerAudioSource.PlayOneShot(windUpSounds[Random.Range(0, windUpSounds.Count)]);
    }
}