using UnityEngine;
using Sirenix.OdinInspector;

public class VictimClassReferencer : SerializedMonoBehaviour
{
    //probably no need so delete if no use!
    //public ClassManagerConfig victimClassConfig;
    public MeleeWeaponParameters meleeVictimClassConfig;

    public RangedWeaponParameters rangedVictimClassConfig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}