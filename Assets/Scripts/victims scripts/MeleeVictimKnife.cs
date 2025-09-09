using UnityEngine;

[CreateAssetMenu(fileName = "MeleeVictimKnife", menuName = "VictimsClasses/MeleeVictimKnife", order = 1)]
public class MeleeVictimKnife : ScriptableObject
{
    public string name;
    public int health;
    public int strength;
    public float speed;
}
