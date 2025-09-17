using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite hoverSprite;

    public void OnPointerEnter()
    {
        buttonImage.sprite = hoverSprite;
    }

    public void OnPointerExit()
    {
        buttonImage.sprite = normalSprite;
    }
}
