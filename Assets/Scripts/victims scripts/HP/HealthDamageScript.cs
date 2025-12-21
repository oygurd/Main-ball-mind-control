using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.InputSystem;


public class HealthDamageScript : SerializedMonoBehaviour, IDamageable
{
    public ClassManagerConfig victimStats;
    private MeleeWeaponParameters meleeClass;
    private RangedWeaponParameters rangedClass;
    public float Hp;
    public Slider healthSlider;

    // private InputAction test;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hp = victimStats.Health;


        healthSlider.maxValue = Hp;
        healthSlider.value = Hp;
    }

    public void TakeDamage(float damage)
    {
        Hp -= damage;
        healthSlider.value = Hp;
    }
}