using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "VictimClassScriptableObject", menuName = "Scriptable Objects/VictimClassScriptableObject",
    order = 1)]
public class VictimClassScriptableObject : ScriptableObject
{
    [SerializeField] private string name;
    [SerializeField] private Sprite sprite;

    [SerializeField] private WeaponConfig _weaponsConfig;
    [SerializeField]  private float[] extraParameter;
    public void ChangeBetweenTypes()
    {
        switch (_weaponsConfig)
        {
            case RangedWeaponParameters rangeWeapon:
                extraParameter[1] = rangeWeapon.Ammo;
                break;
           case MeleeWeaponParameters meleeWeapon:
               break;
                
        }
    }
    
    public int maxHealth;
    public int currentHealth;

    public float speed;
    public float jumpForce;

    public class onGameStartCheckType : MonoBehaviour
    {
        VictimClassScriptableObject victimClassReference;
        private void Start()
        {
            victimClassReference.ChangeBetweenTypes();
        }
    }
}