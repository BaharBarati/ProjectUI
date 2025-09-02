using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CircleFollower : MonoBehaviour
{
    [SerializeField] private List<RectTransform> button;
    private Tween currentTween;
    private void OnEnable()
    {
        MoveCircle(button[0]);
    }

    public void MoveCircle(RectTransform target)
    {
        if (currentTween != null && currentTween.IsActive())
            currentTween.Kill();
        // transform.position = target.position;(i causes irregular movement)
        
        // transform.DOMove(target.position, 0.3f).SetEase(Ease.InOutSine);
        Sequence mySequence = DOTween.Sequence();
        
        mySequence.Append(transform.DOScale(0.5f, 0.2f).SetEase(Ease.InOutSine));
        
        mySequence.Append(transform.DOMove(target.position, 0.3f).SetEase(Ease.InOutSine));
        
        mySequence.Append(transform.DOScale(1f, 0.2f).SetEase(Ease.InOutSine));
    }
}