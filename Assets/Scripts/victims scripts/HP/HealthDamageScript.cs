using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;


public class HealthDamageScript : SerializedMonoBehaviour
{
    public Slider healthSlider;

    private InputAction test;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        test = InputSystem.actions.FindAction("Test");
    }

    // Update is called once per frame
    void Update()
    {
        if (test.triggered)
        {
            healthSlider.value -= 0.1f;
        }
    }
}