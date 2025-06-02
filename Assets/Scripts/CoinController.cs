using UnityEngine;

public class CoinController : MonoBehaviour
{
    public float rotationSpeed = 180f;
    private Vector3 rotationAxis;
    public float lightIntensity = 1;
    private Light light;
    void Start()
    {
        rotationAxis = Vector3.up;
        light = gameObject.GetComponent<Light>();
        light.range = lightIntensity;
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
             Destroy(gameObject);
         }
     }

}