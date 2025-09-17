using UnityEngine;

public class PlayGameClick : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    public void OnClick()
    {
        canvas.SetActive(false);
    }
}
