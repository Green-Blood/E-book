using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private string _ballText, _correctBallText;
     

    public void OnBallClick()
    {  
        _ballText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        _correctBallText = StadiumManager.Instance.correctBall.GetComponentInChildren<TextMeshProUGUI>().text;
        if (_ballText == _correctBallText)
        {
            Debug.Log("EndGame");
        }
    }
}
