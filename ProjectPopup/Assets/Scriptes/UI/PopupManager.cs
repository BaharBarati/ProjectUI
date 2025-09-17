// using UnityEngine;
// using UnityEngine.Serialization;
//
// public class PopupManager : MonoBehaviour
// {
//     [SerializeField] private GameObject SettingPopup;
//     [SerializeField] private GameObject MainPage;
//     public void OpenSettingPopup()
//     {
//         SettingPopup.SetActive(true);
//         MainPage.SetActive(false);
//     }
// }
using UnityEngine;
using DG.Tweening;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingPopup;
    [SerializeField] private GameObject MainPage;
    private CanvasGroup settingCanvasGroup;

    private void Awake()
    {
        if (SettingPopup != null)
        {
            settingCanvasGroup = SettingPopup.GetComponent<CanvasGroup>();
            if (settingCanvasGroup == null)
                settingCanvasGroup = SettingPopup.AddComponent<CanvasGroup>();

            // حالت اولیه پنهان
            settingCanvasGroup.alpha = 0f;

            SettingPopup.SetActive(false);
        }
    }

    public void OpenSettingPopup()
    {
        if (SettingPopup != null)
        {
            SettingPopup.SetActive(true);

            settingCanvasGroup.alpha = 0f;

            settingCanvasGroup.DOFade(1f, 0.5f);
        }

        if (MainPage != null)
            MainPage.SetActive(false);
    }

    public void CloseSettingPopup()
    {
        if (SettingPopup != null)
        {

            settingCanvasGroup.DOFade(0f, 0.5f).OnComplete(() =>
            {
                SettingPopup.SetActive(false);
            });
        }

        if (MainPage != null)
            MainPage.SetActive(true);
    }
}
