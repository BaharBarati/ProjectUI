using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageFade : MonoBehaviour
{
    [SerializeField] private Image myImage;

    public void OnOpenPage()
    {
        Color c = myImage.color;
        c.a = 0f;
        myImage.color = c;


        myImage.DOFade(1f, 1f);
    }

    public void OnClosePage()
    {
        Color c = myImage.color;
        c.a = 0f;
        myImage.color = c;
    }
    void OnEnable()
    {
        Color c = myImage.color;
        c.a = 0f;
        myImage.color = c;
    
    
        myImage.DOFade(1f, 1f);
       
    }

    private void OnDisable()
    {
        Color c = myImage.color;
        c.a = 0f;
        myImage.color = c;
    }
}