using DG.Tweening;
using UnityEngine;

namespace Playground
{
    public class LoadingView : MonoBehaviour
    {
        [SerializeField] private RectTransform indicatorImageRectTransform;
        [SerializeField] private Vector3 endValue;
        [SerializeField] private float animationTime;

        private Tween anim;

        private void OnEnable()
        {
            StartAnimation();
        }

        private void OnDisable()
        {
            StopAnimation();
        }

        private void StartAnimation()
        {
            anim = indicatorImageRectTransform.DOLocalRotate(endValue, animationTime, RotateMode.FastBeyond360)
                   .SetLoops(-1);
        }

        private void StopAnimation()
        {
            anim?.Kill();
        }
    }
}
