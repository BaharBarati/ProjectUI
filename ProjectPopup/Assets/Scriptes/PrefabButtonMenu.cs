using UnityEngine;
using TMPro;
public class PrefabButtonMenu : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateButton("Quests");
        CreateButton("Profile");
        CreateButton("Settings");
        CreateButton("Friends");
    }
    void CreateButton(string buttonText)
    {
        GameObject newButton = Instantiate(prefab , rectTransform);
        TMP_Text textComponent = newButton.GetComponentInChildren<TMP_Text>();
        textComponent.text = buttonText;
        Debug.Log("ساخت دکمه: " + buttonText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
