using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Playground
{
    public class LoadingView : MonoBehaviour
    {
        [Header("Indicator")]
        [SerializeField] private RectTransform indicatorImageRectTransform;
        [SerializeField] private Vector3 endValue;
        [SerializeField] private float animationTime;
        
        [Header("Loading Image")]
        [SerializeField] private Image loadingImage;
        [SerializeField] private float changeTime = 0.5f;
        [SerializeField] private int maxImagesCount = 3;
        
        private float timer;
        private int index;
        private Tween anim;

        private void OnEnable()
        {
            StartAnimation();
        }

        private void Start()
        {
            index = 0;
            timer = changeTime;
            SetLoadingSprite();
        }

        private void OnDisable()
        {
            StopAnimation();
        }

        private void OnDestroy()
        {
            Resources.UnloadUnusedAssets();
        }

        private void Update()
        {
            timer -= Time.deltaTime;

            if (timer > 0)
                return;

            index++;
            timer = changeTime;

            if (index >= maxImagesCount)
                index = 0;

            SetLoadingSprite();
        }

        private void StartAnimation()
        {
            anim = indicatorImageRectTransform.DOLocalRotate(endValue, animationTime, RotateMode.FastBeyond360)
                   .SetLoops(-1);
        }

        private void StopAnimation()
        {
            anim?.Kill();
            anim = null;
        }

        private void SetLoadingSprite()
        {
            var sprite = Resources.Load<Sprite>($"Loading/Loading{index}");
            loadingImage.sprite = sprite;
        }
    }
}
