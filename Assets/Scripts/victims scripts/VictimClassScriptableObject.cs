using UnityEngine;

[CreateAssetMenu(fileName = "VictimClassScriptableObject", menuName = "Scriptable Objects/VictimClassScriptableObject", order = 1)]
public class VictimClassScriptableObject : ScriptableObject
{
    public string name;
    public Sprite sprite;
    
    public enum WeaponType
    {
        Melee,
        Ranged
    }
    [SerializeField] WeaponType _weaponType;
    public int maxHealth;
    public int currentHealth;
    
    public int strength;
    public float speed;
    public float jumpForce;

}
