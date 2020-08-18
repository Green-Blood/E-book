using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class NumberGenerator : MonoBehaviour
{

    [Header("UI Objects")] 
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject[] clouds;
    
    private List<int> uniqueNumbers;
    private bool listCreated = false;

    private int[] _options = new int[9];
    private int[] _terms = new int[9];

    [Header("Parameters")]
    [SerializeField] private int numberToGenerate;
    
    public void Start()
    {
        uniqueNumbers = new List<int>();
        numberToGenerate = Random.Range(10, 25);
        GenerateNumber(numberToGenerate);
        gate.GetComponentInChildren<TextMeshProUGUI>().text = numberToGenerate.ToString();
    }

    public void ResetClouds( )
    {
        for (int i = 0; i < clouds.Length; i++)
        {
            clouds[i].GetComponent<CloudDragHandler>().ClearCloud();
        }
        
    }

    private void GenerateNumber(int number)
    {
        CreateRandomList(1, numberToGenerate);
        for (int i = 0; i < 8; i += 2)
        {
            _terms[i] = GetUniqueRandom(1, numberToGenerate);
            _terms[i+1] = numberToGenerate - _terms[i];
        }
        _terms[8] = GetUniqueRandom(1, numberToGenerate);

        CreateRandomList(1, 9);
        for (int i = 0; i < 9; i++)
        {
            _options[GetUniqueRandom(0, 9)] = _terms[i];
        }

        for (int i = 0; i < clouds.Length; i++)
        {
            clouds[i].GetComponentInChildren<TextMeshProUGUI>().text = _options[i].ToString();
        }
    }
    private void CreateRandomList(int min, int max)
    {
        uniqueNumbers.Clear();

        for(int i = min; i < max; i++)
        {
            uniqueNumbers.Add(i);
        }
    }
    private int GetUniqueRandom(int min, int max)
    {
        int randNum = 0;

        if (uniqueNumbers.Count == 0)
        {
            CreateRandomList(min, max);
        }

        randNum = uniqueNumbers[Random.Range(0,uniqueNumbers.Count)];
        uniqueNumbers.Remove(randNum);
        
        return randNum;
    } 

}
