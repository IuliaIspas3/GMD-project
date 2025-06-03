using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static TextMeshProUGUI coinText;
    public TextMeshProUGUI coinTextReference;

    public static TextMeshProUGUI controlsText;
    public TextMeshProUGUI controlsTextReference;

    void Awake()
    {
        coinText = coinTextReference;
        controlsText = controlsTextReference;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IntroScene"); 
        }
    }
    
    public static void SetMessage(string message, Color color)
    {
        if (controlsText != null)
        {
            controlsText.text = message;
            controlsText.color = color;
            Debug.LogWarning(message);
        }
    }

    public static void ClearMessage()
    {
        if (controlsText != null)
            controlsText.text = "";
    }
}