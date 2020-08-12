using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiguresDraw
{
    public class Pentagon : MonoBehaviour, IFigures
    {
        public void DrawFigure()
        {
            var manager = StadiumManager.Instance;
            
            if (manager.figuresSprites != null) manager.figure.GetComponent<Image>().overrideSprite = manager.figuresSprites[3];
            manager.figure.GetComponent<Image>().DOFillAmount(1, manager.fillTime);
        
            // Used only for square(probably will be changed in future)
            foreach (var scoreTag in manager.tags)
            {
                scoreTag.GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[0].ToString();
            }

            // Should be changed in future
            manager.tags[3].transform.DOLocalMoveX(160f, 0);
            manager.tags[4].transform.DOLocalMoveX(-145f, 0);
            
            // Draws balls and puts correct answer value
            manager.DrawBalls(manager.figureValues[0] * 5);
            StartCoroutine(ScoreActivate(5));
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
