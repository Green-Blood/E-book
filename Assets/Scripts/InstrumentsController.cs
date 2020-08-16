using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class InstrumentsController : MonoBehaviour
{
    [SerializeField] private GameObject[] leftObjects;
    [SerializeField] private GameObject[] rightObjects;

    [SerializeField] private SpriteRenderer[] lamps; //0 index - red lamp; 1 index - green lamp;

    [SerializeField] private string correctAnswer;
    
    private int _numberOfLeftObjects;
    private int _numberOfRightObjects;
    private List<int> _uniqueNumbers;
    private Tween lampTween;
    
    private void Start()
    {
        _uniqueNumbers = new List<int>();
        GenerateInstruments();
        FindCorrectAnswer();
    }

    public void CreateRandomList(int min, int max)
    {
        _uniqueNumbers.Clear();

        for(int i = min; i < max; i++)
        {
            _uniqueNumbers.Add(i);
        }
    }
    public int GetUniqueRandom(int min, int max)
    {
        int randNum = 0;

        if (_uniqueNumbers.Count == 0)
        {
            CreateRandomList(min, max);
        }

        randNum = _uniqueNumbers[Random.Range(0,_uniqueNumbers.Count)];
        _uniqueNumbers.Remove(randNum);
        
        return randNum;
    }

    private void GenerateInstruments()
    {
        _numberOfLeftObjects = Random.Range(1, leftObjects.Length);
        _numberOfRightObjects = Random.Range(1, rightObjects.Length);

        for (int i = 0; i < _numberOfLeftObjects; i++)
        {
            leftObjects[GetUniqueRandom(0,_numberOfLeftObjects)].SetActive(true);
        }
        
        _uniqueNumbers = new List<int>();
        
        for (int i = 0; i < _numberOfRightObjects; i++)
        {
            rightObjects[GetUniqueRandom(0,_numberOfRightObjects)].SetActive(true);
        }
    }

    private void FindCorrectAnswer()
    {
        if (_numberOfLeftObjects > _numberOfRightObjects)
            correctAnswer = "Greater";
        else if (_numberOfLeftObjects < _numberOfRightObjects)
            correctAnswer = "Less";
        else
            correctAnswer = "Equal";
    }
    
    
    public void CheckAnswer(string answerToCheck)
    {
        if (correctAnswer == answerToCheck)
        {
            lampTween?.Kill();
            lampTween = lamps[1].DOFade(1f, 0.5f)
                .OnKill(() =>
                {
                    lamps[1].color = new Color(255, 255,255, 0);
                })
                .SetLoops(2, LoopType.Yoyo);
        }
        else
        {
            lampTween?.Kill();
            lampTween = lamps[0].DOFade(1f, 0.3f)
                .OnKill(() =>
                {
                    lamps[0].color = new Color(255, 255,255, 0);
                })
                .SetLoops(6, LoopType.Yoyo);
        }
    }
}
