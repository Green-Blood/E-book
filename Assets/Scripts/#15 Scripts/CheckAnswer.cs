using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
     
    [SerializeField] private GameObject gate;
    
    [SerializeField] private TextMeshProUGUI[] windowsText;
    
    private int _answer;
    private int _correct;
    
    // Hope this shit will be changed
    private void Start()
    {
        _answer = int.Parse(gate.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    private void Update()
    {
        if (int.Parse(windowsText[0].text) + int.Parse(windowsText[1].text)  == _answer)
        {
              
        }
       
    }

    public void CheckCorrect()
    {
        if (int.Parse(windowsText[0].text) + int.Parse(windowsText[1].text)  == _answer)
        {
            _correct++;
        }
        if (int.Parse(windowsText[2].text) + int.Parse(windowsText[3].text)  == _answer)
        {
            _correct++;
        }
        if (int.Parse(windowsText[4].text) + int.Parse(windowsText[5].text)  == _answer)
        {
            _correct++;
        }

        if (_correct > 2)
        {
            Debug.Log("Lox");
        }
    }
}
