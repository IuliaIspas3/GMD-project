using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Buildings");
    }
}