using System.Collections.Generic;
using Audio;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;

    [Header("DEBUG")]
    [SerializeField] private SfxType debugSfxType;
    [SerializeField] private Transform debugTransform;

    private AudioSettings audioSettings;

    private readonly List<GameAudioSource> sfxSources = new List<GameAudioSource>();

    public float MusicVolume => bgmSource.volume;
    public float SfxVolume { get; private set; } = 1f;

    [Inject]
    public void Construct(AudioSettings audioSettings)
    {
        this.audioSettings = audioSettings;
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

    public void SetMusicVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    public void SetSfxVolume(float volume)
    {
        SfxVolume = volume;

        foreach (var gameAudioSource in sfxSources)
        {
            gameAudioSource.SetVolume(volume);
        }
    }

    public void PlaySfx(SfxType sfxType, Transform transform = null)
    {
        if (transform != null && !transform.gameObject.activeSelf)
        {
            // log error

            return;
        }

        var audioSource = CreateAudioSource(transform);
        SetupAudioSource(audioSource, audioSettings.GetSfxInfo(sfxType));
    }

    public void PlayMusic(MusicType musicType)
    {
    }

    private GameAudioSource CreateAudioSource(Transform transform)
    {
        var transformForAudioSource = transform == null ? this.transform : transform;
        var audioSource = transformForAudioSource.gameObject.AddComponent<GameAudioSource>()
               .OnKill(AudioSourceKilled);

        sfxSources.Add(audioSource);

        return audioSource;
    }

    private void AudioSourceKilled(GameAudioSource audioSource)
    {
        sfxSources.Remove(audioSource);
    }

    private void SetupAudioSource(GameAudioSource audioSource, SfxInfo sfxInfo)
    {
        audioSource.Setup(sfxInfo, SfxVolume);
        audioSource.Play();
    }

    private AudioClip GetAudioClip(SfxType sfxType)
    {
        return audioSettings.GetAudioClip(sfxType);
    }

    [Button()]
    private void PlayDebugSfx()
    {
        PlaySfx(debugSfxType, debugTransform);
    }
}
