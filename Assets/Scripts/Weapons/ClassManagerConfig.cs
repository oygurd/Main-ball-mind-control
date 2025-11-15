using UnityEngine;
using System;
using System.ComponentModel;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

// This code is for the stats of the victims and their classes, do not delete this!
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/ClassManagerConfig")]
public class ClassManagerConfig : SerializedScriptableObject
{
    [TabGroup("Class", "Base Stats", SdfIconType.Heart)]
    public float Health, movementSpeed, jumpStrength;
    
    [TabGroup("Class", "Base Stats", SdfIconType.Heart)]
    public GameObject WeaponPrefab;

    [PreviewField(60)] [OnInspectorGUI] public Sprite icon;
}

[Serializable]
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/RangedConfig")]
public class RangedWeaponParameters : ClassManagerConfig
{
    [TabGroup("Class", "Ranged class stats", SdfIconType.ArrowUp, TextColor = "red")]
    public float baseDamage, weaponRange;
    [TabGroup("Class", "Ranged class stats", SdfIconType.ArrowUp, TextColor = "red")]
    public int Ammo, MaxAmmo;
}

[Serializable]
[InlineEditor]
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/MeleeConfig")]
public class MeleeWeaponParameters : ClassManagerConfig
{
    [TabGroup("Class", "Melee class stats", SdfIconType.Magic, TextColor = "red")]
    public float baseDamage, extraHP, attackRange, attackSpeed;

    [TabGroup("Class", "Melee Class Ability stats", SdfIconType.Activity, TextColor = "Green")]
    public float dashAttackCD, DashStrengthX, DashStrengthY, ParryCd, ParryRange;
}