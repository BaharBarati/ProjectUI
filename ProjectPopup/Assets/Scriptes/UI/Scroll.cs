using UnityEngine;
using UnityEngine.EventSystems;

public class PassScroll : MonoBehaviour, IScrollHandler
{
    public void OnScroll(PointerEventData eventData)
    {
        // به parent ScrollRect پاس بده
        ExecuteEvents.ExecuteHierarchy<IScrollHandler>(
            transform.parent.gameObject, eventData, ExecuteEvents.scrollHandler);
    }
}