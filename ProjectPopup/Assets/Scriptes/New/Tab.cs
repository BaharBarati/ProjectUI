using System;
using UnityEngine;
using UnityEngine.Serialization;
using Animation = Scriptes.New.Animation;

public class Tab : MonoBehaviour
{
    public int index;
    public Animation enterAnimation;
    

    public void Reset()
    {
        transform.localScale = Vector3.one;
        var canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
        // canvasGroup.interactable = true;
        // canvasGroup.blocksRaycasts = true;
    }

    public void ExecuteEnterAnimation()
    {
        // enterAnimation.Kill();
        enterAnimation.PlayInward(gameObject);
        Debug.Log($"Execute Enter animation:{gameObject.name}");
    }

    public void ExecuteExistAnimation(Animation animation, Action onFinish)
    {
        // animation.Kill();
        animation.PlayBackwards(gameObject, onFinish);
        Debug.Log($"Execute Exist animation:{gameObject.name}");
    }
}