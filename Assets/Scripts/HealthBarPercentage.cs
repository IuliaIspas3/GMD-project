using UnityEngine;
using UnityEngine.UI;

public class HealthBarPercentage : MonoBehaviour
{
    public Image healthImage;
    public Text percentageText;

    void Update()
    {
        if (healthImage != null && percentageText != null)
        {
            float percentage = healthImage.fillAmount * 100f;
            percentageText.text = percentage.ToString("F0") + "%";
        }
    }
}