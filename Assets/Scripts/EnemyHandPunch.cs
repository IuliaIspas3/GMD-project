using UnityEngine;

public class EnemyHandPunch : MonoBehaviour
{
    public float damageAmount = 0.1f;
    public float damageCooldown = 0.1f;

    private float lastDamageTime = -900f;
    private HealthBarFiller healthBar;


    void Start()
    {
        GameObject healthBarObject = GameObject.Find("HealthBarCanvas");
        if (healthBarObject != null)
        {
            healthBar = healthBarObject.GetComponentInChildren<HealthBarFiller>();
        }

        if (healthBar == null)
        {
            Debug.LogError("HealthBarFiller not found! Make sure it's assigned or findable in the scene.");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Character") && Time.time - lastDamageTime >= damageCooldown)
        {
            Debug.Log("Punch hit the character!");

            if (healthBar != null)
            {
                Debug.Log("Damage applied!");
                healthBar.ApplyDamage(damageAmount);
                lastDamageTime = Time.time;

            }
        }
    }
}