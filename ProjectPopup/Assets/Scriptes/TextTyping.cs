using System.Collections;
using TMPro;
using UnityEngine;

public class TypewriterText : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private float typingSpeed = 0.05f; 

    private Coroutine typingCoroutine;

    private void OnEnable()
    {
        if (tmpText == null) tmpText = GetComponent<TMP_Text>();
        
        tmpText.maxVisibleCharacters = 0;

        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(PlayTypewriter());
    }

    private IEnumerator PlayTypewriter()
    {
        int totalChars = tmpText.textInfo.characterCount;

        for (int i = 0; i <= totalChars; i++)
        {
            tmpText.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}