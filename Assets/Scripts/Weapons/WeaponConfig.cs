using UnityEngine;

[CreateAssetMenu(fileName = "WeaponConfig", menuName = "Scriptable Objects/WeaponConfig")]
public class WeaponConfig : ScriptableObject
{
    [SerializeField] private float damage;
    [SerializeField] private float range;
}


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