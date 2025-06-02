using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigateButton : MonoBehaviour
{
    public string sceneName;
    public void LoadGame()
    {
        SceneManager.LoadScene(sceneName);
    }
}