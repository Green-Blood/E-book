using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class StadiumManager : SingletonClass<StadiumManager>
{
    [Header("Figure")]
    [SerializeField] private Sprite[] figuresSprites;
    [SerializeField] private GameObject figure;
    [SerializeField] private Figures.FiguresEnum figuresEnum;
    
    [Header("Answer")]
    [SerializeField] private GameObject[] tags;
    [SerializeField] private GameObject[] balls;
    [SerializeField] private GameObject ballsBackground;

    [Header("Parameters")]
    [SerializeField] private float fillTime;
    [SerializeField] private float randomRange;
    // Can be changed in future
    [SerializeField] private int[] figureValues;

    private TextMeshProUGUI[] _tagText;
    public GameObject correctBall;
    
     

    private void Start()
    {
        // Create figures dependent on Enum
        switch (figuresEnum)
        {
            case Figures.FiguresEnum.Square:
                CreateSquare();
                break;
            case Figures.FiguresEnum.IsoscelesTriangle:
                break;
            case Figures.FiguresEnum.Rectangle:
                break;
            case Figures.FiguresEnum.Pentagon:
                break;
            case Figures.FiguresEnum.Triangle:
                break;
            case Figures.FiguresEnum.Hexagon:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void CreateSquare()
    {
        if (figuresSprites != null) figure.GetComponent<Image>().overrideSprite = figuresSprites[0];
        figure.GetComponent<Image>().DOFillAmount(1, fillTime);
        
        // Used only for square(probably will be changed in future)
        foreach (var scoreTag in tags)
        {
            scoreTag.GetComponentInChildren<TextMeshProUGUI>().text = figureValues[0].ToString();
        } 
        
        StartCoroutine(ScoreActivate());

        float answer = figureValues[0] * 4;

        for (int i = 0; i < balls.Length; i++)
        {
            // Probably will be changed in future too.
            balls[i].GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(answer - randomRange, answer + randomRange).ToString("F0");
        }

        correctBall = balls[Random.Range(0, balls.Length)];
        correctBall.GetComponentInChildren<TextMeshProUGUI>().text = answer.ToString("F0");
    }
    
    private IEnumerator ScoreActivate()
    {
        WaitForSeconds wait = new WaitForSeconds( 1f ) ;
        // Can put declaration in Awake in future 
        foreach (var scoreTag in tags)
        {
            // Shows tags and put values there
            scoreTag.SetActive(true);
            scoreTag.transform.DOScale(1, 0.5f);
           
            yield return wait;
        }

        // Shows balls;
        ballsBackground.transform.DOMoveY(97.5f, fillTime);
        yield return wait;
        foreach (var ball in balls)
        {
            ball.transform.DOScale(1, 0.25f);
            yield return wait;
        }

    }


}
