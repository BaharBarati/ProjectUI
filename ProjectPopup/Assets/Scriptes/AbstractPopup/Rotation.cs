// using System;
// using UnityEngine;
// using UnityEngine.UI;
// using DG.Tweening;
// using Animation = Scriptes.New.Animation;
//
// public class Rotation : Tab
// {
//     [SerializeField]  private CanvasGroup _canvasGroup;
//     private void Awake()
//     {
//         transform.rotation = Quaternion.Euler(0, 0, 180); // شروع چرخیده
//         gameObject.SetActive(false);
//     }
//
//     public override void ExecuteFadeInAnimation(Animation animation)
//     {
//         LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
//         gameObject.SetActive(true);
//         transform.rotation = Quaternion.Euler(0, 0, 180);
//         transform.DORotate(Vector3.zero, 1.5f).SetEase(Ease.OutBack);
//     }
//
//     public override void ExecuteFadeOutAnimation(Animation animation)
//     {
//         LayoutRebuilder.ForceRebuildLayoutImmediate(_canvasGroup.GetComponent<RectTransform>());
//         transform.DORotate(new Vector3(0, 0, 180), 1.5f)
//             .SetEase(Ease.InBack)
//             .OnComplete(() => gameObject.SetActive(false));
//     }
// }
