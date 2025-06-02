using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthBarFiller : MonoBehaviour
{
    public Image healthImage;

    void Start()
    {
        if (healthImage != null)
            healthImage.fillAmount = 1f;
    }

    public void ApplyDamage(float amount)
    {
        if (healthImage == null) return;

        healthImage.fillAmount = Mathf.Clamp01(healthImage.fillAmount - amount);

        if (healthImage.fillAmount <= 0f)
        {
            Debug.Log("Player is dead.");
            SceneManager.LoadScene("GameOverScene");
        }
    }
}