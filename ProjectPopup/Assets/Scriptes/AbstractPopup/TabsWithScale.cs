using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TabsWithScale : AbstractTabs
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }
    public override void OpenPopup(Animation animation)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
        gameObject.SetActive(true);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    public override void ClosePopup(Animation animation)
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack)
            .OnComplete(() => gameObject.SetActive(false));
    }
}
