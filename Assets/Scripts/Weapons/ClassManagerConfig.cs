using UnityEngine;
using System;
using System.ComponentModel;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

// This code is for the stats of the victims and their classes, do not delete this!
[CreateAssetMenu(fileName = "ClassManagerConfig", menuName = "Classes/ClassManagerConfig")]
public class ClassManagerConfig : ScriptableObject
{
    [BoxGroup("Basic Stats")] public float Health;
    [BoxGroup("Basic Stats")] public string weaponName;
    [BoxGroup("Basic Stats")] public float movementSpeed;
    [BoxGroup("Basic Stats")] public float jumpStrength;
    [BoxGroup("Basic Stats")] [PreviewField(60)]
    [OnInspectorGUI]
    public Sprite icon;
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
    [field: SerializeField] public float baseDamage { get; private set; }
    [field: SerializeField] public float extraHP { get; private set; }
    [field: SerializeField] public float attackRange { get; private set; }
    [field: SerializeField] public float attackSpeed { get; private set; }
    [field: SerializeField] public float attackCD { get; private set; }
    [field: SerializeField] public float parryWindup { get; private set; }
    [field: SerializeField] public float DashStrengthX { get; private set; }
    [field: SerializeField] public float DashStrengthY { get; private set; }
    [field: SerializeField] public float dashAttackCD { get; private set; }

    [field: SerializeField] public GameObject prefab { get; private set; }
}