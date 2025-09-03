using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject BlackPanel;
    
    [SerializeField] private List<Toggle> toggles;
    private int currentIndex = 0;
    // // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     BlackPanel.SetActive(false);
    // }

    // Update is called once per frame
    void Update()
    {
        // if (toggles.Count == 0) return;

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = toggles.Count - 1;
            }

            toggles[currentIndex].isOn = true;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            currentIndex++;
            if (currentIndex >= toggles.Count)
            {
                currentIndex = 0;
            }
            toggles[currentIndex].isOn= true;
        }
    }

    public void OnChangePageStatus(bool state)
    {
        
    }
}
