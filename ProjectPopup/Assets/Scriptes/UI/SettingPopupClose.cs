using UnityEngine;

public class SettingPopupClose : MonoBehaviour
{
    [SerializeField] private GameObject BlackPanel;
    [SerializeField] private GameObject MainPage;
    public void PoppupClosing()
    {
        BlackPanel.SetActive(false);
        MainPage.SetActive(true);
    }
}

