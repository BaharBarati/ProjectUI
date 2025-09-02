using UnityEngine;

public class SettingPopupClose : MonoBehaviour
{
    [SerializeField] private GameObject BlackPanel;
    public void PoppupClosing()
    {
        BlackPanel.SetActive(false);
    }
}

