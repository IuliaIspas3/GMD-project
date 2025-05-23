using UnityEngine;
using System.Collections;
public class LampScripts : MonoBehaviour
{
    public Light spotLight;
    [Header("Lamp Settings")]
        public float minBlinkInterval = 0.05f;
        public float maxBlinkInterval = 0.3f;
        public int minBlinks = 2;
        public int maxBlinks = 6;
        public float waitBetweenCycles = 3f;
    
        private void Start()
        {
            if (spotLight == null)
            {
                spotLight = GetComponent<Light>();
            }
    
            if (spotLight == null || spotLight.type != LightType.Spot)
            {
                Debug.LogWarning("BrokenLamp script requires a Spot Light assigned or attached to the GameObject.");
                enabled = false;
                return;
            }
    
            StartCoroutine(BlinkLoop());
        }
    
        private IEnumerator BlinkLoop()
        {
            while (true)
            {
                int blinkCount = Random.Range(minBlinks, maxBlinks + 1);
                
                for (int i = 0; i < blinkCount; i++)
                {
                    spotLight.enabled = false;
                    yield return new WaitForSeconds(Random.Range(minBlinkInterval, maxBlinkInterval));
    
                    spotLight.enabled = true;
                    yield return new WaitForSeconds(Random.Range(minBlinkInterval, maxBlinkInterval));
                }
    
                yield return new WaitForSeconds(waitBetweenCycles);
            }
        }
    }