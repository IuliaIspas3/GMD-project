using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeToIntro : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("IntroScene"); 
        }
    }
}