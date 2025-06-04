using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
        if (Input.GetKeyDown(KeyCode.Escape) || Gamepad.current.rightTrigger.ReadValue() > 0.5f)
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "street-map" || currentScene == "GameOver" || currentScene == "WinningScene")
            {
                SceneManager.LoadScene("IntroScene");
            }
            else
            {
                Application.Quit(); 
                #if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;
                #endif
            }
        }

        if (Gamepad.current.leftTrigger.ReadValue() > 0.5f) 
        {
            string currentScene = SceneManager.GetActiveScene().name;
            if (currentScene == "IntroScene")
            {
                SceneManager.LoadScene("street-map");
            }
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