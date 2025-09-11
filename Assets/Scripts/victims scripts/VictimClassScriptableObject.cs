using UnityEngine;

[CreateAssetMenu(fileName = "VictimClassScriptableObject", menuName = "Scriptable Objects/VictimClassScriptableObject",
    order = 1)]
public class VictimClassScriptableObject : ScriptableObject
{
    public string name;
    public Sprite sprite;


    public MeleeTypeWeaponScript meleeClassScriptable;
    public RangedTypeWeaponScript rangedClassScriptable;

    public enum WeaponType
    {
        Melee,
        Ranged
    }

    public float WeaponPower;
    public float WeaponRange;

    [SerializeField] WeaponType _weaponType;

    public WeaponType typeSwitch()
    {
        switch (_weaponType)
        {
            case WeaponType.Melee:
                if (meleeClassScriptable != null)
                {
                    WeaponPower = meleeClassScriptable.power;
                    WeaponRange = meleeClassScriptable.range;
                }

                break;
            case WeaponType.Ranged:
                if (rangedClassScriptable != null)
                {
                    WeaponPower = rangedClassScriptable.power;
                    WeaponRange = rangedClassScriptable.range;
                }
                break;
        }

        return _weaponType;
    }

    public int maxHealth;
    public int currentHealth;

    public float speed;
    public float jumpForce;
}