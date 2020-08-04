using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
    [SerializeField] private GameObject firstLine;
    [SerializeField] private GameObject secondLine;
    [SerializeField] private GameObject thirdLine;
    [SerializeField] private GameObject gate;
    private TextMeshProUGUI _firstWindow;
    private TextMeshProUGUI _secondWindow; 
    private TextMeshProUGUI _thirdWindow; 
    private TextMeshProUGUI _fourthWindow; 
    private TextMeshProUGUI _fifthWindow; 
    private TextMeshProUGUI _sixthWindow;
    private int _answer;
    
    private void Start()
    {
        /*for (int i = 0; i < windows.Length; i++)
        {
            _firstWindow[i] = windows[i].transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
            _secondWindow[i] = windows[i].transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        }*/
        
        _firstWindow = firstLine.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _secondWindow = firstLine.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        
        _thirdWindow = secondLine.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _fourthWindow = secondLine.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        
        _fifthWindow = thirdLine.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        _sixthWindow = thirdLine.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>();
        
        _answer = int.Parse(gate.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    private void Update()
    {
        if (Check(_fifthWindow,_secondWindow) && Check(_thirdWindow,_fourthWindow) && Check(_fifthWindow, _sixthWindow))
        {
            Debug.Log("Lox");
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
