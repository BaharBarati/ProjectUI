using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ButtonInsideMenu : MonoBehaviour
{
    [SerializeField] private Image background; 
    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoverColor;
    private Vector3 originalScale;
    [SerializeField] private TextMeshProUGUI text;
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
        text.color = new Color(50f, 50f, 50f);
    }

    public void OnHoverEnter()
    {
        transform.DOScale(originalScale * 1.05f, 0.2f).SetEase(Ease.OutBack);
        
        if (background != null)
            background.DOColor(hoverColor, 0.2f);

        panel.SetActive(true);
        text.color = new Color(1f, 1f, 1f);
    }

    public void OnHoverExit()
    {
        transform.DOScale(originalScale, 0.2f).SetEase(Ease.OutBack);

        if (background != null)
            background.DOColor(normalColor, 0.2f);
        panel.SetActive(false);
        text.color = new Color(0.2f, 0.2f, 0.2f);
    }
}
