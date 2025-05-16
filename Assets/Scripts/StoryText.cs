using TMPro;
using UnityEngine;
using System.Collections;

public class TypewriterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string fullText;
    private string currentText = "";

    private TextMeshProUGUI textComponent;

    void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            // If there's a newline character, handle it
            if (fullText[i] == '\\' && i + 1 < fullText.Length && fullText[i + 1] == 'n')
            {
                currentText += "\n"; // Add the actual line break
                i++; // Skip the 'n' after '\\'
            }
            else
            {
                currentText += fullText[i]; // Add the current character
            }

            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}