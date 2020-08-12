using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace FiguresDraw
{
    public class IsoscelesTriangle : MonoBehaviour, IFigures
    {
        public void DrawFigure()
        {
            var manager = StadiumManager.Instance;
            
            if (manager.figuresSprites != null) manager.figure.GetComponent<Image>().overrideSprite = manager.figuresSprites[1];
            manager.figure.GetComponent<Image>().DOFillAmount(1, manager.fillTime);
        
            // Used only for square(probably will be changed in future)
            for (int i = 0; i < 3; i++)
            {
                manager.tags[i].GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[i].ToString();
            }
            // Shit code
            manager.tags[3].GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[2].ToString();
            manager.tags[1].transform.DOLocalMoveY(75f, 0);
             
 
            // Draws balls and puts correct answer value
            manager.DrawBalls(manager.figureValues[0] + manager.figureValues[1] + manager.figureValues[2]);
            
            StartCoroutine(ScoreActivate(4));
        }

        private IEnumerator ScoreActivate(int angles)
        {
            var manager = StadiumManager.Instance;
            var wait = new WaitForSeconds( 1f ) ;
            
            for (int i = 0; i < angles; i++)
            {
                // Shows tags and put values there
                manager.tags[i].SetActive(true);
                manager.tags[i].transform.DOScale(1, 0.5f);
                manager.tags[2].SetActive(false);
                
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