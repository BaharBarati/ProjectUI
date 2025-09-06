using System;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FadingForScreen : AbstractTabs
{
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Awake()
    {
        if (_canvasGroup == null)
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
        // _canvasGroup.alpha = 0;
        // gameObject.SetActive(false);
    }

    public override void OpenPopup(Animation animation)
    {
        // LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
        gameObject.SetActive(true);
        // _canvasGroup.alpha = 0;
        // _canvasGroup.interactable = true;
        // _canvasGroup.blocksRaycasts = true;
        // _canvasGroup.DOFade(1, 1.5f).SetEase(Ease.OutBack);
        animation.PlayInward(_canvasGroup.gameObject);
    }

    public override void ClosePopup(Animation animation)
    {
        // _canvasGroup.interactable = false;
        // _canvasGroup.blocksRaycasts = false;
        // LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
        // _canvasGroup.DOFade(0f, 1.5f).OnComplete(() => { gameObject.SetActive(false); });
        animation.PlayBackwards(_canvasGroup.gameObject, () =>
        {
            gameObject.SetActive(false);
        });
    }
}

public class Animation
{
    public void PlayInward(GameObject gameObject)
    {
        var _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
        _canvasGroup.DOFade(1, 1.5f).SetEase(Ease.OutBack);
    }

    public void PlayBackwards(GameObject gameObject,Action doneAction = null)
    {
        var _canvasGroup = gameObject.GetComponent<CanvasGroup>();
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
        LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
        _canvasGroup.DOFade(0f, 1.5f).OnComplete(()=>doneAction?.Invoke());
    }
}