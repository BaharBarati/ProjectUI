using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Animation = Scriptes.New.Animation;

public class ScreenTab : Tab
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Awake()
    {
        if (_canvasGroup == null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
    }
    
}

