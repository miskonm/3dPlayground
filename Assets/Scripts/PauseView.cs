using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseView : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private float animationTime;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private AudioManager audioManager;

    private Tweener tweener;

    [Inject]
    public void Construct(AudioManager audioManager)
    {
        this.audioManager = audioManager;
    }

    private void Awake()
    {
        gameObject.SetActive(false);
        canvasGroup.alpha = 0;
    }

    private void Update()
    {
        audioManager.SetMusicVolume(musicSlider.value);
        musicSlider.value = audioManager.MusicVolume;

        audioManager.SetSfxVolume(sfxSlider.value);
        sfxSlider.value = audioManager.SfxVolume;
    }

    public void Show()
    {
        SetupSliders();

        gameObject.SetActive(true);
        tweener?.Kill();

        var time = CalculateTime(true);
        tweener = canvasGroup
               .DOFade(1, time)
               .SetUpdate(true);
    }

    public void Hide()
    {
        tweener?.Kill();

        var time = CalculateTime(false);
        tweener = canvasGroup
               .DOFade(0, time)
               .SetUpdate(true)
               .OnComplete(() => gameObject.SetActive(false));
    }

    private void SetupSliders()
    {
    }

    private float CalculateTime(bool isShowing)
    {
        var currentAlpha = canvasGroup.alpha;
        var ration = isShowing ? currentAlpha / 1f : currentAlpha;

        return ration * animationTime;
    }
}
