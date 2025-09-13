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

    [SerializeField] public WeaponConfig _weaponsConfig;
    [SerializeField] public string[] getTypesNames;

    public enum WeaponType
    {
        Melee,
        Ranged
    }

    public void GetTypes()
    {
        getTypesNames = _weaponsConfig.TypesNames;
    }
    
    
    /*public void ChangeBetweenTypes()
    {
        switch (_weaponsConfig)
        {
            case RangedWeaponParameters rangeWeapon:
                parameters[1] = rangeWeapon.Ammo;
                break;

            case MeleeWeaponParameters meleeWeapon:
                parameters[1] = meleeWeapon.extraHP;
                break;
        }
    }*/

    public int maxHealth;
    public int currentHealth;

    public float speed;
    public float jumpForce;

    /*public class OnGameStartCheckType : MonoBehaviour
    {
        public WeaponConfig _weaponsConfig;

        private void Start()
        {
            foreach (string type in _weaponsConfig.TypesNames)
            {
                for (int i = 0; i < _weaponsConfig.TypesValues.Count; i++)
                {
                    _weaponsConfig.TypesValues.Add(i);
                }
            }
        }

        /*private void Start()
        {
            victimClassReference.ChangeBetweenTypes();
        }#1#
    }*/
}