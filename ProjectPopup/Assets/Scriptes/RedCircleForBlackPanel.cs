using UnityEngine;
using DG.Tweening;
public class RedCircleForBlackPanel : MonoBehaviour
{
    [SerializeField] private RectTransform redCircle;

    public void MoveCircle(RectTransform rectTransform)
    {
        redCircle.DOMove(rectTransform.position, 0.3f).SetEase(Ease.OutQuad);
    }
}
