using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiguresDraw
{
    public class Rectangle : MonoBehaviour, IFigures
    {
        public void DrawFigure()
        {
            var manager = StadiumManager.Instance;
            if (manager.figuresSprites != null) manager.figure.GetComponent<Image>().overrideSprite = manager.figuresSprites[2];
            manager.figure.GetComponent<Image>().DOFillAmount(1, manager.fillTime);
        
            // Used only for square(probably will be changed in future)
            for (int i = 0; i < manager.tags.Length; i++)
            {
                // Move tags, hopefully better solution will be provided.
                switch (i)
                {
                    case 0:
                        manager.tags[i].GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[1].ToString();
                        manager.tags[i].transform.DOLocalMoveX(-385f, 0);
                        break;
                    case 2:
                        manager.tags[i].GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[1].ToString();
                        manager.tags[i].transform.DOLocalMoveX(385f, 0);
                        break;
                    default:
                        manager.tags[i].GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[0].ToString();
                        break;
                }
            }
        
         
        
            StartCoroutine(ScoreActivate(4));
            // Draws balls with answer.
            manager.DrawBalls(((manager.figureValues[0] + manager.figureValues[1]) * 2) );
        }
        private IEnumerator ScoreActivate(int angles)
        {
            WaitForSeconds wait = new WaitForSeconds( 1f ) ;
            var manager = StadiumManager.Instance;
            // Can put declaration in Awake in future 
            for (int i = 0; i < angles; i++)
            {
                // Shows tags and put values there
                manager.tags[i].SetActive(true);
                manager.tags[i].transform.DOScale(1, 0.5f);
                
                yield return wait;
            }

            // Shows balls;
            manager.ballsBackground.transform.DOMoveY(0, manager.fillTime);
            yield return wait;
            foreach (var ball in manager.balls)
            {
                ball.transform.DOScale(0.85f, 0.25f);
                yield return wait;
            }
        }
    }
}
