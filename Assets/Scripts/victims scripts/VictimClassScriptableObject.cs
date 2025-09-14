using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "VictimClassScriptableObject", menuName = "Scriptable Objects/VictimClassScriptableObject",
    order = 1)]
public class VictimClassScriptableObject : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Sprite sprite;


    
    public int maxHealth;
    public int currentHealth;

    public float speed;
    public float jumpForce;

   
}