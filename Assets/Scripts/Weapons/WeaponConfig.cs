using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEditor;

[Serializable]
[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/WeaponConfig")]
[AddComponentMenu("test")]
public class WeaponConfig : ScriptableObject
{
    public string weaponName;
}


[Serializable]
[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/RangedConfig")]
public class RangedWeaponParameters : WeaponConfig
{
    [field: SerializeField] public Sprite icon { get; private set; }
    public GameObject weaponPrefab;
    [field: SerializeField] public float damage { get; private set; }
    [field: SerializeField] public int Ammo { get; private set; }
    [field: SerializeField] public int MaxAmmo { get; private set; }
    [field: SerializeField] public float weaponRange { get; private set; }
}
[Serializable]
[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/MeleeConfig")]
public class MeleeWeaponParameters : WeaponConfig
{
    [field: SerializeField] public float extraHP { get; private set; }
    [field: SerializeField] public float range { get; private set; }
    [field: SerializeField] public float attackSpeed { get; private set; }
}

/*public class TypeChanger : MonoBehaviour
{
    WeaponConfig _weaponConfigType;
    private void Start()
    {
        switch (_weaponConfigType)
        {
            case RangedWeaponParameters rangeWeapon:
                _weaponConfigType.Types.Add(rangeWeapon.Ammo);
                break;

            case MeleeWeaponParameters meleeWeapon:
                _weaponConfigType.Types.Add(meleeWeapon.extraHP);
                break;
        }
    }
}*/