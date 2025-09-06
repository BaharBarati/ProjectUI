using UnityEngine;
using System.Collections.Generic;

public class AnimationPopup : MonoBehaviour
{
     [SerializeField] private List<AbstractTabs> popups;
//     private int currentPopupIndex = -1;
//     
//     public void GoToPopup(int nextIndex)
//     {
//         if (nextIndex < 0 || nextIndex >= popups.Count)
//             return;
//
//         Abstract nextPopup = popups[nextIndex];
//
//         if (currentPopupIndex != -1)
//         {
//             Abstract currentPopup = popups[currentPopupIndex];
//
//             currentPopup.ClosePopup(nextPopup.openAnimationType);
//         }
//
//         nextPopup.OpenPopup();
//         currentPopupIndex = nextIndex;
//     }
}