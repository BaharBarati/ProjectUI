// using UnityEngine;
// using UnityEngine.UI;
// using System.Collections.Generic;
// using Animation = Scriptes.New.Animation;
//
// public class Manager : MonoBehaviour
// {
//     [SerializeField] private GameObject BlackPanel;
//     
//     [SerializeField] private List<Toggle> toggles;
//     private int currentIndex = 0;
//
//     [SerializeField] private List<Tab> panels;
//     void Start()
//     {
//         for (int i = 0; i < toggles.Count; i++)
//         {
//             int index = i;
//             toggles[i].onValueChanged.AddListener((isOn) =>
//             {
//                 if (isOn)
//                 {
//                     ShowOnly(index);
//                 }
//             });
//         }
//         ShowOnly(0);
//     }
//
//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Q))
//         {
//             currentIndex--;
//             if (currentIndex < 0)
//             {
//                 currentIndex = toggles.Count - 1;
//             }
//
//             toggles[currentIndex].isOn = true;
//         }
//         else if (Input.GetKeyDown(KeyCode.W))
//         {
//             currentIndex++;
//             if (currentIndex >= toggles.Count)
//             {
//                 currentIndex = 0;
//             }
//             toggles[currentIndex].isOn= true;
//         }
//     }
//     private void ShowOnly(int index)
//     {
//         for (int i = 0; i < panels.Count; i++)
//         {
//             if (i == index)
//                 panels[i].ExecuteFadeInAnimation(new Animation());
//             else
//                 panels[i].ExecuteFadeOutAnimation(new Animation());
//         }
//     }
// }
