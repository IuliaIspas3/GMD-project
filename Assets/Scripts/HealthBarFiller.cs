using UnityEngine;
using UnityEngine.UI;

public class HealthBarFiller : MonoBehaviour
{
    public Image healthImage;
    public float decreaseAmount = 0.1f;   // Decrease by 10% every minute
    public float interval = 5f;          // Time in seconds between decreases

    private float timer = 0f;

    void Start()
    {
        if (healthImage != null)
            healthImage.fillAmount = 1f;  // Start full or set to a custom value
    }

    void Update()
    {
        if (healthImage == null || healthImage.fillAmount <= 0f)
            return;

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            healthImage.fillAmount = Mathf.Clamp01(healthImage.fillAmount - decreaseAmount);
            timer = 0f;
        }
    }
}