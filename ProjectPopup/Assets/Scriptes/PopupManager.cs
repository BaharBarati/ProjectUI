using UnityEngine;
using UnityEngine.Serialization;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject SettingPopup;
    public void OpenSettingPopup()
    {
        SettingPopup.SetActive(true);
    }
}
