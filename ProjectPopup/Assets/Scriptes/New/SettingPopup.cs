using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using DG.Tweening;

namespace Scriptes.New
{
    public enum AnimationExecutionStateFromAToB
    {
        Done,
        ExitA,
        EnterB
    }

    public class SettingPopup : MonoBehaviour
    {
        private int _lastSelectedTabIndex;
        [SerializeField] private List<Tab> tabs;
        [SerializeField] private List<Toggle> toggles;
        private int currentIndex = 0;
        private AnimationExecutionStateFromAToB animationExecutionState = AnimationExecutionStateFromAToB.Done;

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
            // if(animationExecutionState != AnimationExecutionStateFromAToB.Done) return;
            Debug.Log("ChangeTab Called");
            var selectedTab = tabs[index];
            var lastSelectedTab = tabs[_lastSelectedTabIndex];
            if (lastSelectedTab.index == selectedTab.index)
            {
                if (animationExecutionState == AnimationExecutionStateFromAToB.ExitA)
                {
                    selectedTab.Reset();
                    selectedTab.ExecuteEnterAnimation(() =>
                    {
                        animationExecutionState = AnimationExecutionStateFromAToB.Done;
                    });
                }
                return;
            }
            
            
            Debug.Log($"Last Selected Tab:{lastSelectedTab.name}  + \n" +
                      $"$\"Selected Tab:{selectedTab.name}" + "\n" +
                      $"Animation Execution State:{animationExecutionState}");
            if (animationExecutionState == AnimationExecutionStateFromAToB.ExitA)
            {
                animationExecutionState = AnimationExecutionStateFromAToB.ExitA;
                lastSelectedTab.KillAnimation();
                lastSelectedTab.ExecuteExitAnimation(selectedTab.enterAnimation,
                    () =>
                    {
                        lastSelectedTab.gameObject.SetActive(false);
                        lastSelectedTab.Reset();
                        selectedTab.gameObject.SetActive(true);
                        animationExecutionState = AnimationExecutionStateFromAToB.EnterB;
                        selectedTab.ExecuteEnterAnimation(() =>
                        {
                            animationExecutionState = AnimationExecutionStateFromAToB.Done;
                        });
                        _lastSelectedTabIndex = selectedTab.index;
                    });
            }
            else if (animationExecutionState == AnimationExecutionStateFromAToB.EnterB)
            {
                animationExecutionState = AnimationExecutionStateFromAToB.ExitA;
                lastSelectedTab.KillAnimation();
                lastSelectedTab.ExecuteExitAnimation(selectedTab.enterAnimation,
                    () =>
                    {
                        lastSelectedTab.gameObject.SetActive(false);
                        lastSelectedTab.Reset();
                        selectedTab.gameObject.SetActive(true);
                        animationExecutionState = AnimationExecutionStateFromAToB.EnterB;
                        selectedTab.ExecuteEnterAnimation(() =>
                        {
                            animationExecutionState = AnimationExecutionStateFromAToB.Done;
                        });
                        _lastSelectedTabIndex = selectedTab.index;
                    });
            }
            else if (animationExecutionState == AnimationExecutionStateFromAToB.Done)
            {
                animationExecutionState = AnimationExecutionStateFromAToB.ExitA;
                lastSelectedTab.ExecuteExitAnimation(selectedTab.enterAnimation,
                    () =>
                    {
                        // lastSelectedTab.gameObject.SetActive(false);
                        // selectedTab.gameObject.SetActive(true);

                        lastSelectedTab.gameObject.SetActive(false);
                        lastSelectedTab.Reset();

                        selectedTab.gameObject.SetActive(true);
                        animationExecutionState = AnimationExecutionStateFromAToB.EnterB;
                        selectedTab.ExecuteEnterAnimation(() =>
                        {
                            animationExecutionState = AnimationExecutionStateFromAToB.Done;
                        });
                        _lastSelectedTabIndex = selectedTab.index;
                    });
            }
        }
    }
}