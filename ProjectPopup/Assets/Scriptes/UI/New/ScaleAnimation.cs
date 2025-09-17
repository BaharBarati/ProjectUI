using System;
using DG.Tweening;
using UnityEngine;

namespace Scriptes.New
{
    [CreateAssetMenu(fileName = "ScaleAnimation", menuName = "TabAnimations/ScaleAnimation", order = 1)]
    public class ScaleAnimation : Animation
    {
        
        private bool isAnimationKilled;
        private Tween enterAnimation;
        private Tween exitAnimation;
        
        
        public override void PlayInward(GameObject gameObject , Action doneAction = null)
        {
            isAnimationKilled = false;
            var _canvasGroup = gameObject.GetComponent<CanvasGroup>();
            // _canvasGroup.interactable = true;
            // _canvasGroup.blocksRaycasts = true;
            // _canvasGroup.alpha = 1;
            gameObject.transform.localScale = Vector3.zero;
            enterAnimation = gameObject.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.OutBack).OnComplete(() =>
            {
                if(isAnimationKilled) return;
                
                doneAction?.Invoke();
            });
        }

        public override void PlayBackwards(GameObject gameObject, Action doneAction = null)
        {
            isAnimationKilled = false;
            
            exitAnimation = gameObject.transform.DOScale(Vector3.zero, 0.7f)
                .SetEase(Ease.InBack)
                .OnComplete(() =>
                {
                    // _canvasGroup.alpha = 0;
                    // _canvasGroup.interactable = false;
                    // _canvasGroup.blocksRaycasts = false;
                    if(isAnimationKilled) return;
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