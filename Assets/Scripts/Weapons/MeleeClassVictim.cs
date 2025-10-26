using System;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.InputSystem;
public class MeleeClassVictim : SerializedMonoBehaviour
{
    public MeleeWeaponParameters MeleeWeaponParameters;
    
    public Melee_AnimationsHandler melee_animationsHandler;

    public InputAction BasicAttackInput;
    public InputAction ParryInput;
    public InputAction ThrowableInput;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
