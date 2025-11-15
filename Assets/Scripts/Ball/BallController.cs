using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallController : SerializedMonoBehaviour
{
    BallAttachDettachController _ballAttachDettachController;

    public bool canUseAbilities;
    
    private void Update()
    {
        if (_ballAttachDettachController.isHeld)
        {
            canUseAbilities = false;
        }
    }



    public void Whisper()
    {
        
    }

    public void SmallRoll()
    {
        
    }
    
}