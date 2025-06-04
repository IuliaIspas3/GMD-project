using UnityEngine;
using UnityEngine.SceneManagement;

public class CoinController : MonoBehaviour
{
    public float rotationSpeed = 180f;
    private Vector3 rotationAxis;
    public static int coinCount = 0;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rotationAxis = Vector3.up;
        coinCount = 0;
    }

    void Update()
    {
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime, Space.World);
    }
    
     void OnTriggerEnter(Collider other)
     {
        Debug.Log("Tag is: " + other.tag);
    
         if (other.CompareTag("CharacterParent"))
         {
             Debug.Log("Coin collected!");
             coinCount++;
             if (GameManager.coinText != null)
                 GameManager.coinText.text = coinCount.ToString();
             if (coinCount >= 10)
             {
                 SceneManager.LoadSceneAsync("WinningScene");
             }

             audioSource.Play();
             Destroy(gameObject, audioSource.clip.length);

         }
     }

}