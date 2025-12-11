using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class HealthDamageScript : SerializedMonoBehaviour
{
    public Slider healthSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthSlider.value -= 10;
        }
    }
}
