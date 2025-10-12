using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class VictimClassValidator : SerializedMonoBehaviour  //this script will control attacking as well.
{
    [OdinSerialize] static ClassManagerConfig classDefaultParams;
    [OdinSerialize] static RangedWeaponParameters rangedClassParams;
    [OdinSerialize] static MeleeWeaponParameters meleeClassParams;


    [Header("Class Inputs")] //this function is meant to be used as a switch between classes based on what it got on the start of the game
    public GameObject meleeClass;

    public GameObject rangedClass;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ValidateClass()
    {
        if (classDefaultParams is RangedWeaponParameters ranged)
        {
            rangedClass.SetActive(true);
        }
        else if (classDefaultParams is MeleeWeaponParameters melee)
        {
            meleeClass.SetActive(true);
        }
    }
}