using UnityEngine;

[CreateAssetMenu(fileName = "MeleeTypeWeaponScript", menuName = "Scriptable Objects/MeleeTypeWeaponScript")]
public class MeleeTypeWeaponScript : ScriptableObject
{
    public Sprite icon;
    public float power;
    public float range;
}
