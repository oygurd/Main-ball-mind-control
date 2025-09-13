using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    /*[SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private float fireRate;
    [SerializeField] private float reloadTime;*/

    [SerializeField] public string[] TypesNames =
    {
        "Speed",
        "JumpHeight",
        "Damage",
        "Range",
        "Fire Rate",
        "Reload Time",
        "extraHP",
    };

    [SerializeField] public List<float> TypesValues;
}


/*[Serializable]
[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/RangedConfig")]
public class RangedWeaponParameters : WeaponConfig
{
    [field: SerializeField] public int Ammo { get; private set; }
}

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/MeleeConfig")]
public class MeleeWeaponParameters : WeaponConfig
{
    [field: SerializeField] public float extraHP { get; private set; }
}

public class TypeChanger : MonoBehaviour
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