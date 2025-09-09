using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonInsideMenu : MonoBehaviour
{
    [SerializeField] private Image background; 
    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoverColor;
    private Vector3 originalScale;

    [SerializeField] private GameObject panel; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    
    void Start()
    {
        originalScale = transform.localScale;
        if (background != null) 
        background.color = normalColor;
    }

    private void OnDisable()
    {
        transform.DOScale(originalScale, 0.2f).SetEase(Ease.OutBack);

        if (background != null)
            background.DOColor(normalColor, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnHoverEnter()
    {
        transform.DOScale(originalScale * 1.05f, 0.2f).SetEase(Ease.OutBack);
        
        if (background != null)
            background.DOColor(hoverColor, 0.2f);

        panel.SetActive(true);
    }

    public void OnHoverExit()
    {
        transform.DOScale(originalScale, 0.2f).SetEase(Ease.OutBack);

        if (background != null)
            background.DOColor(normalColor, 0.2f);
        panel.SetActive(false);
    }
}
