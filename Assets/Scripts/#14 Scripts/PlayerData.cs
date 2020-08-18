using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public PlayerScript thePlayerScript;
    public CameraScript theCameraScript;
    public CoinGenerator coinGenerator;

    private void Awake()
    {
        instance = this;
    }
}
