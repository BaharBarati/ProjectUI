using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Scriptes.New
{
    [CreateAssetMenu(fileName = "RotateFadeAnimation", menuName = "TabAnimations/RotateFadeAnimation", order = 6)]
    public class RotateFadeAnimation : Animation
    {
        private bool isAnimationKilled;
        private Tween enterAnimation;
        private Tween exitAnimation;

        public override void PlayInward(GameObject gameObject, Action doneAction = null)
        {
            isAnimationKilled = false;

            var transform = gameObject.transform;
            var canvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();
            
            transform.localRotation = Quaternion.Euler(0, 0, -20);
            canvasGroup.alpha = 0f;

            enterAnimation = DOTween.Sequence()
                .Join(transform.DORotate(Vector3.zero, 1f).SetEase(Ease.OutBack))
                .Join(canvasGroup.DOFade(1f, 0.7f))
                .OnComplete(() =>
                {
                    if (isAnimationKilled) return;
                    doneAction?.Invoke();
                });
        }

        public override void PlayBackwards(GameObject gameObject, Action doneAction = null)
        {
            isAnimationKilled = false;

            var transform = gameObject.transform;
            var canvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();

            exitAnimation = DOTween.Sequence()
                .Join(transform.DORotate(new Vector3(0, 0, -20), 1f).SetEase(Ease.InBack))
                .Join(canvasGroup.DOFade(0.5f, 0.7f))
                .OnComplete(() =>
                {
                    if (isAnimationKilled) return;
                    doneAction?.Invoke();
                });
        }

        public override void KillAnimation()
        {
            isAnimationKilled = true;
            exitAnimation?.Kill();
            enterAnimation?.Kill();
        }
    }
}