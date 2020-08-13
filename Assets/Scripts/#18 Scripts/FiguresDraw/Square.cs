using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace FiguresDraw
{
    public class Square : MonoBehaviour, IFigures
    {
        public void DrawFigure()
        {
            var manager = StadiumManager.Instance;
            
            if (manager.figuresSprites != null) manager.figure.GetComponent<Image>().overrideSprite = manager.figuresSprites[0];
            manager.figure.GetComponent<Image>().DOFillAmount(1, manager.fillTime);
        
            // Used only for square(probably will be changed in future)
            foreach (var scoreTag in manager.tags)
            {
                scoreTag.GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[0].ToString();
            }
            
            // Draws balls and puts correct answer value
            manager.DrawBalls(manager.figureValues[0] * 4);
            StartCoroutine(ScoreActivate(4));
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

            StartCoroutine(manager.ShowBalls());
        }
    }
}
