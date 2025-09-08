using System;
using DG.Tweening;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Scriptes.New
{
    // [MenuItem("")]
    [CreateAssetMenu(fileName = "FadeAnimation", menuName = "TabAnimations/FadeAnimation", order = 1)]
    public class FadeAnimation : Animation
    {
        // private Tween currentDOTween;
        public override void PlayInward(GameObject gameObject)
        {

            var _canvasGroup = gameObject.GetComponent<CanvasGroup>();
            // gameObject.SetActive(true);
            _canvasGroup.alpha = 0; 
            _canvasGroup.DOFade(1, 0.7f).SetEase(Ease.OutBack);
        }

        public override void PlayBackwards(GameObject gameObject,Action doneAction = null)
        {
            var _canvasGroup = gameObject.GetComponent<CanvasGroup>();
            
            // LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
            _canvasGroup.DOFade(0f, 0.7f).OnComplete(()=>
            {
                // _canvasGroup.interactable = false;
                // _canvasGroup.blocksRaycasts = false;
                
                // gameObject.SetActive(false);
                doneAction?.Invoke();
            });
        }
        // public override void Kill()
        // {
        //     if (currentDOTween != null && currentDOTween.IsActive())
        //     {
        //         currentDOTween.Kill();
        //         currentDOTween = null;
        //     }
        // }
    }
}