using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class BallController : SerializedMonoBehaviour
{
    BallAttachDettachController _ballAttachDettachController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Update()
    {
        if (_ballAttachDettachController.isHeld)
        {
            
        }
    }



    public void Whisper()
    {
        
    }
}