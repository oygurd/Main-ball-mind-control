using UnityEngine;
using System;
using System.ComponentModel;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

// This code is for the stats of the victims and their classes, do not delete this!
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/ClassManagerConfig")]
public class ClassManagerConfig : ScriptableObject
{
    [TabGroup("Class", "Base Stats", SdfIconType.Heart)]
    public float Health, movementSpeed, jumpStrength;

    [PreviewField(60)] [OnInspectorGUI] public Sprite icon;
}

[Serializable]
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/RangedConfig")]
public class RangedWeaponParameters : ClassManagerConfig
{
    public GameObject weaponPrefab;
    [field: SerializeField] public float baseDamage { get; private set; }
    [field: SerializeField] public int Ammo { get; private set; }
    [field: SerializeField] public int MaxAmmo { get; private set; }
    [field: SerializeField] public float weaponRange { get; private set; }
}

[Serializable]
[InlineEditor]
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/MeleeConfig")]
public class MeleeWeaponParameters : ClassManagerConfig
{
    [TabGroup("Class", "Melee class stats", SdfIconType.Magic, TextColor = "red")]
    public float baseDamage, extraHP, attackRange, attackSpeed, parryWindup;

    public float DashStrengthX { get; private set; }
    public float DashStrengthY { get; private set; }
    public float dashAttackCD { get; private set; }

    [field: SerializeField] public GameObject prefab { get; private set; }
}