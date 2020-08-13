using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FiguresDraw
{
    public class Hexagon : MonoBehaviour, IFigures
    {
        public void DrawFigure()
        {
            var manager = StadiumManager.Instance;
            
            if (manager.figuresSprites != null) manager.figure.GetComponent<Image>().overrideSprite = manager.figuresSprites[5];
            manager.figure.GetComponent<Image>().DOFillAmount(1, manager.fillTime);
        
            // Used only for square(probably will be changed in future)
            foreach (var scoreTag in manager.tags)
            {
                scoreTag.GetComponentInChildren<TextMeshProUGUI>().text = manager.figureValues[0].ToString();
            }

            // MoveTags : Should be changed in future
            manager.tags[0].transform.DOLocalMoveX(-400f, 0);
            manager.tags[1].transform.DOLocalMove( new Vector3(-170f, 325f) , 0);
            manager.tags[2].transform.DOLocalMoveX( 400f , 0);
            manager.tags[3].transform.DOLocalMove( new Vector3(170f, 325f) , 0);
            manager.tags[4].transform.DOLocalMove( new Vector3(160f, -200f) , 0);
            manager.tags[5].transform.DOLocalMove( new Vector3(-160f, -200f) , 0);
             
            
            // Draws balls and puts correct answer value
            manager.DrawBalls(manager.figureValues[0] * 6);
            StartCoroutine(ScoreActivate(6));
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