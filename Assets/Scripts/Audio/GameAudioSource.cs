using System;
using UnityEngine;

namespace Audio
{
    public class GameAudioSource : MonoBehaviour
    {
        private AudioSource audioSource;
        private SfxInfo sfxInfo;
        private float globalVolume;

        private bool isStarted;

        private Action<GameAudioSource> onKill;

        private void Awake()
        {
            audioSource = gameObject.AddComponent<AudioSource>();

            if (sfxInfo != null)
                Setup();
        }

        private void Update()
        {
            if (!isStarted)
                return;
            
            if (!audioSource.isPlaying)
            {
                Kill();
            }
        }

        public void Setup(SfxInfo sfxInfo, float globalSfxVolume)
        {
            this.sfxInfo = sfxInfo;
            globalVolume = globalSfxVolume;

            if (audioSource == null)
                return;
            
            Setup();
        }

        private void Setup()
        {
            audioSource.clip = sfxInfo.Clip;
            audioSource.volume = sfxInfo.Volume * globalVolume;
            audioSource.pitch = sfxInfo.Pitch;
        }

        public void SetVolume(float globalSfxVolume)
        {
            globalVolume = globalSfxVolume;

            if (audioSource == null)
                return;
            
            audioSource.volume = sfxInfo.Volume * globalSfxVolume;
        }

        public GameAudioSource OnKill(Action<GameAudioSource> onKill)
        {
            this.onKill = onKill;

            return this;
        }

        public void Play()
        {
            audioSource.Play();
            isStarted = true;
        }

        private void Kill()
        {
            onKill?.Invoke(this);

           
        }
    }
}
