using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    [SerializeField] private GameObject[] windows;
    [SerializeField] private GameObject gate;
    private TextMeshProUGUI[] _firstWindow;
    private TextMeshProUGUI[] _secondWindow; 
    private int _answer;
    
    private void Start()
    {
        for (int i = 0; i < windows.Length; i++)
        {
            _firstWindow[i] = windows[i].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            _secondWindow[i] = windows[i].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        }
        
        //_firstWindow = windows.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        //_secondWindow = windows.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        _answer = int.Parse(gate.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    private void Update()
    {
        if (Check(_firstWindow[0], _secondWindow[0]) && Check(_firstWindow[1], _secondWindow[1]) && Check(_firstWindow[2], _secondWindow[2]))
        {
            Debug.Log("Asmo Rak");
        }
       
    }

    private bool Check(TextMeshProUGUI text1, TextMeshProUGUI text2)
    {
        if (text1.text != "" && text2.text != "")
        {
            return int.Parse(text1.text) + int.Parse(text1.text) == _answer;
        }

        return false;
    }
}
