using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    public float rotationSpeed = 180f;
    private Vector3 rotationAxis;
    public static int coinCount = 0;

    void Start()
    {
        rotationAxis = Vector3.up;
    }

    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);
    }
    
     void OnTriggerEnter(Collider other)
     {
        Debug.Log("Tag is: " + other.tag);
    
         if (other.CompareTag("Character"))
         {
             Debug.Log("Coin collected!");
             coinCount++;
             if (GameManager.coinText != null)
                 GameManager.coinText.text = coinCount.ToString();
             if (coinCount >= 10)
                 SceneManager.LoadScene("WinningScene");
             Destroy(gameObject);
         }
     }

}