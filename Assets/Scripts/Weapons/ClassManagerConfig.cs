using UnityEngine;
using System;
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/ClassManagerConfig")]
public class ClassManagerConfig : ScriptableObject
{
    public string weaponName;
    public float movementSpeed;
    public float JumpStrength;
}

[Serializable]
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/RangedConfig")]
public class RangedWeaponParameters : ClassManagerConfig
{
    [field: SerializeField] public Sprite icon { get; private set; }
    public GameObject weaponPrefab;
    [field: SerializeField] public float damage { get; private set; }
    [field: SerializeField] public int Ammo { get; private set; }
    [field: SerializeField] public int MaxAmmo { get; private set; }
    [field: SerializeField] public float weaponRange { get; private set; }
    
}
[Serializable]
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/MeleeConfig")]
public class MeleeWeaponParameters : ClassManagerConfig
{
    [field: SerializeField] public Sprite icon { get; private set; }
    [field: SerializeField] public float extraHP { get; private set; }
    [field: SerializeField] public float DashStrengthX { get; private set; }
    [field: SerializeField] public float DashStrengthY { get; private set; }


    [field: SerializeField] public float range { get; private set; }
    [field: SerializeField] public float attackSpeed { get; private set; }
    [field: SerializeField] public float attackCD { get; private set; }
    [field: SerializeField] public float dashAttackCD { get; private set; }

    [field: SerializeField] public GameObject prefab { get; private set; }
    


}