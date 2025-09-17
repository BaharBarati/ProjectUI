using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageFade : MonoBehaviour
{
    [SerializeField] private Image myImage;

    public void OnEnable()
    {
        Color c = myImage.color;
        c.a = 0f;
        myImage.color = c;
    
    
        myImage.DOFade(1f, 0.5f);
    }
    
    private void OnDisable()
    {
        Color c = myImage.color;
        c.a = 0f;
        myImage.color = c;

    }
}