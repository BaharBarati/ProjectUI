// using UnityEngine;
//
// public class Test : MonoBehaviour
// {
//     public void Testing()
//     {
//         Debug.Log("Test");
//     }
// }
using UnityEngine;
using DG.Tweening;

public class Blend2DExample : MonoBehaviour
{
    void Start()
    {
        // Move the object 3 units to the right over 2 seconds (blendable)
        transform.DOBlendableMoveBy(new Vector3(10, 0, 0), 2);
        // After 1 second, move it 2 units up (smoothly blends with the previous move)
        transform.DOBlendableMoveBy(new Vector3(0, 20, 0), 2).SetDelay(1);
    }
}

