using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PageFade : MonoBehaviour
{
    [SerializeField] private Image myImage;
    [SerializeField] private CanvasGroup myCanvasGroup=>GetComponent<CanvasGroup>();

    public void OnOpenPage(bool state)
    {
        if (state)
        {
            // Color c = myImage.color;
            // c.a = 0f;
            // myImage.color = c;


           // myImage.DOFade(1.0f, 1f);
            myCanvasGroup.DOFade(1.0f, 0.5f);
        }
        else
        {
            // Color c = myImage.color;
            // c.a = 1.0f;
            // myImage.color = c;


            //myImage.DOFade(0.0f, 1f);
            myCanvasGroup.DOFade(0.0f, 0.5f);
        }
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