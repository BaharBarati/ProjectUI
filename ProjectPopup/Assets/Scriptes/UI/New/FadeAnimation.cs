using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Scriptes.New
{
    // [MenuItem("")]
    [CreateAssetMenu(fileName = "FadeAnimation", menuName = "TabAnimations/FadeAnimation", order = 1)]
    public class FadeAnimation : Animation
    {
        private bool isAnimationKilled;
        private Tween enterAnimation;
        private Tween exitAnimation;
        
        public override void PlayInward(GameObject gameObject , Action doneAction = null)
        {
            isAnimationKilled = false;

            var _canvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();
            _canvasGroup.alpha = 0; 
            enterAnimation = _canvasGroup.DOFade(1, 0.5f).SetEase(Ease.InBack).OnComplete(() =>
            {
                if(isAnimationKilled) return;
                
                doneAction?.Invoke();
            });
        }

        public override void PlayBackwards(GameObject gameObject,Action doneAction = null)
        {
            isAnimationKilled = false;
            
            var _canvasGroup = gameObject.GetOrAddComponent<CanvasGroup>();
            exitAnimation = _canvasGroup.DOFade(0f, 0.5f).OnComplete(()=>
            {
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