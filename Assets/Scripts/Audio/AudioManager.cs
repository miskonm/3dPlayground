using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;
    
    [SerializeField] private AudioSettings  audioSettings;
    
    
    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    [Button()]
    private void PlayMusic()
    {
        bgmSource.Play();
    }

    [Button()]
    private void StopMusic()
    {
        bgmSource.Stop();
    }

    public void SetVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void PlaySfx(SfxType sfxType, Transform transform = null)
    {
        var audioClip = GetAudioClip(sfxType);
        var audioSource = CreateAudioSource(transform);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    private AudioSource CreateAudioSource(Transform transform)
    {
        var transformForAudioSource = transform == null ? this.transform : transform;
        var audioSource = transformForAudioSource.gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        audioSource.playOnAwake = true;

        return audioSource;
    }

    private AudioClip GetAudioClip(SfxType sfxType)
    {
        return audioSettings.GetAudioClip(sfxType);
    }
}
