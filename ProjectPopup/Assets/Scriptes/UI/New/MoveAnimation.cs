using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace Scriptes.New
{
    [CreateAssetMenu(fileName = "MoveAnimation", menuName = "TabAnimations/MoveAnimation", order = 3)]
    public class MoveAnimation : Animation
    {
        private bool isAnimationKilled;
        private Tween enterAnimation;
        private Tween exitAnimation;

        [SerializeField] private float offset = 500f;
        [SerializeField] private float duration = 1f;

        // پوزیشن اصلی آبجکت (یک بار ذخیره می‌کنیم)
        private Vector2? originalPos;

        public override void PlayInward(GameObject gameObject, Action doneAction = null)
        {
            isAnimationKilled = false;

            var rectTransform = gameObject.transform as RectTransform;

            // فقط دفعه اول پوزیشن اصلی ذخیره بشه
            if (originalPos == null)
                originalPos = rectTransform.anchoredPosition;

            rectTransform.anchoredPosition = originalPos.Value + new Vector2(offset, 0);

            enterAnimation = rectTransform
                .DOAnchorPos(originalPos.Value, duration)
                .SetEase(Ease.OutBack)
                .OnComplete(() =>
                {
                    if (isAnimationKilled) return;
                    doneAction?.Invoke();
                });
        }

        public override void PlayBackwards(GameObject gameObject, Action doneAction = null)
        {
            isAnimationKilled = false;

            var rectTransform = gameObject.transform as RectTransform;

            if (originalPos == null)
                originalPos = rectTransform.anchoredPosition;

            exitAnimation = rectTransform
                .DOAnchorPos(originalPos.Value - new Vector2(offset, 0), duration)
                .SetEase(Ease.InBack)
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
