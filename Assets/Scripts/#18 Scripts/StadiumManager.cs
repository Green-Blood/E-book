using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using FiguresDraw;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class StadiumManager : SingletonClass<StadiumManager>
{
    [Header("Figure")]
    public Sprite[] figuresSprites;
    public GameObject figure;
    [SerializeField] private Figures.FiguresEnum figuresEnum;

    [Header("Answer")]
    public GameObject[] tags;
    public GameObject[] balls;
    public GameObject ballsBackground;

    [Header("Parameters")]
    public float fillTime;
    [SerializeField] private float randomRange;
    // Can be changed in future
    public int[] figureValues;
    public GameObject correctBall;

    private TextMeshProUGUI[] _tagText;
    private IFigures _currentFigure;
     

    private void Start()
    {
        
        // Create figures dependent on Enum
        switch (figuresEnum)
        {
            case Figures.FiguresEnum.Square:
                _currentFigure = figure.AddComponent<Square>();
                _currentFigure.DrawFigure();
                break;
            case Figures.FiguresEnum.IsoscelesTriangle:
                _currentFigure = figure.AddComponent<IsoscelesTriangle>();
                _currentFigure.DrawFigure();
                break;
            case Figures.FiguresEnum.Rectangle:
                _currentFigure = figure.AddComponent<Rectangle>();
                _currentFigure.DrawFigure();
                break;
            case Figures.FiguresEnum.Pentagon:
                _currentFigure = figure.AddComponent<Pentagon>();
                _currentFigure.DrawFigure();
                break;
            case Figures.FiguresEnum.Triangle:
                _currentFigure = figure.AddComponent<Triangle>();
                _currentFigure.DrawFigure();
                break;
            case Figures.FiguresEnum.Hexagon:
                _currentFigure = figure.AddComponent<Hexagon>();
                _currentFigure.DrawFigure();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void DrawBalls(float answer)
    {
        for (int i = 0; i < balls.Length; i++)
        {
            // Probably will be changed in future too.
            balls[i].GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(answer - randomRange, answer + randomRange).ToString("F0");
        }

        correctBall = balls[Random.Range(0, balls.Length)];
        correctBall.GetComponentInChildren<TextMeshProUGUI>().text = answer.ToString("F0");
    }

    public IEnumerator ShowBalls()
    {
        WaitForSeconds wait = new WaitForSeconds( 1f ) ;
        // Shows balls;
        ballsBackground.transform.DOMoveY(0, fillTime);
        yield return wait;
            
        foreach (var ball in balls)
        {
            ball.transform.DOScale(0.80f, 0.25f);
            yield return wait;
        }
    }

   


}
