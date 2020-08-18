using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private PlayerScript _thePlayerScript;
    private CameraScript _theCameraScript;
    private CoinGenerator _coinGenerator;

   

    private Vector3 _coinPosition;

    private void Start()
    {
        _coinPosition = gameObject.transform.position;
        _thePlayerScript = FindObjectOfType<PlayerScript>();
        _theCameraScript = FindObjectOfType<CameraScript>();
        _coinGenerator = FindObjectOfType<CoinGenerator>();
        
    }

    public void OnCoinClick()
    {
        if (_coinGenerator.GetCoinCount() !=
            int.Parse(gameObject.GetComponentInChildren<TextMeshProUGUI>().text)) return;
        _thePlayerScript.MovePlayer(_coinPosition, 1);
        _theCameraScript.MoveCamera(_coinPosition,  1);
        _coinGenerator.UpdateCoinCount();
        gameObject.SetActive(false);




    }
}
