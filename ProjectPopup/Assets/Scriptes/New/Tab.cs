using System;
using UnityEngine;
using UnityEngine.Serialization;
using Animation = Scriptes.New.Animation;

public class Tab : MonoBehaviour
{
    public int index;
    public Animation enterAnimation;
    
    //cache
    private Animation exitAnimation;
    public void Reset()
    {
        KillAnimation();
        
        transform.localScale = Vector3.one;
        var canvasGroup = gameObject.GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
    }

    public void KillAnimation()
    {
        // stop Enter & Exist Animation
        enterAnimation?.KillAnimation();
        exitAnimation?.KillAnimation();
    }

    public void ExecuteEnterAnimation(Action onFinish)
    {
        enterAnimation.PlayInward(gameObject , onFinish);
        Debug.Log($"Execute Enter animation:{gameObject.name}");
    }

    public void ExecuteExitAnimation(Animation animation, Action onFinish)
    {
        exitAnimation = animation;
        animation.PlayBackwards(gameObject, onFinish);
        Debug.Log($"Execute Exist animation:{gameObject.name}");
    }
}