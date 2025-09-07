using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Scriptes.New
{
    public class SettingPopup : MonoBehaviour
    {
        private int _lastSelectedTabIndex;
        [SerializeField] private List<Tab> tabs;
        [SerializeField] private List<Toggle> toggles;
        private int currentIndex = 0;
        private void Awake()
        {
            _lastSelectedTabIndex = 0;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = toggles.Count - 1;
                }

                toggles[currentIndex].isOn = true;
                ChangeTab(currentIndex);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                currentIndex++;
                if (currentIndex >= toggles.Count)
                {
                    currentIndex = 0;
                }

                toggles[currentIndex].isOn = true;
                ChangeTab(currentIndex);
            }
        }


        private void ChangeTab(int index)
        {
            // lets say we are going from tab a to b
            // set the fadeout animaotin for tab A to be fadeInAnimation tab B
            // execute fadeIn animation tab B after fadeout A
            var selectedTab = tabs[index];
            var lastSelectedTab = tabs[_lastSelectedTabIndex];
            if (lastSelectedTab.index == selectedTab.index)
            {
                return;
            }

            lastSelectedTab.ExecuteExistAnimation(selectedTab.enterAnimation,
                () =>
                {
                    // lastSelectedTab.gameObject.SetActive(false);
                    // selectedTab.gameObject.SetActive(true);
                    
                    lastSelectedTab.gameObject.SetActive(false);
                    selectedTab.gameObject.SetActive(true);
                    lastSelectedTab.Reset();
                    
                    selectedTab.ExecuteEnterAnimation();
                    _lastSelectedTabIndex = selectedTab.index;
                });
        }
    }
}