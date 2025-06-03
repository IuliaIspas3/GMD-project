using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static TextMeshProUGUI coinText;

    public TextMeshProUGUI coinTextReference;

    void Awake()
    {
        coinText = coinTextReference;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IntroScene"); 
        }
    }
}