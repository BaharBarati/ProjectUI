using System;
using DG.Tweening;
using UnityEngine;

namespace Scriptes.New
{
    [CreateAssetMenu(fileName = "ScaleAnimation", menuName = "TabAnimations/ScaleAnimation", order = 1)]
    public class ScaleAnimation : Animation
    {
        public override void PlayInward(GameObject gameObject)
        {
            var _canvasGroup = gameObject.GetComponent<CanvasGroup>();
            // _canvasGroup.interactable = true;
            // _canvasGroup.blocksRaycasts = true;
            // _canvasGroup.alpha = 1;
            gameObject.transform.localScale = Vector3.zero;
            gameObject.transform.DOScale(Vector3.one, 0.7f).SetEase(Ease.OutBack);
        }

        public override void PlayBackwards(GameObject gameObject, Action doneAction = null)
        {
            var _canvasGroup = gameObject.GetComponent<CanvasGroup>();
            
            gameObject.transform.DOScale(Vector3.zero, 0.7f)
                .SetEase(Ease.InBack)
                .OnComplete(() =>
                {
                    // _canvasGroup.alpha = 0;
                    // _canvasGroup.interactable = false;
                    // _canvasGroup.blocksRaycasts = false;
                    
                    doneAction?.Invoke();
                });
        }
    }
}