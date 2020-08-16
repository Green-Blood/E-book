using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class BubbleButtons : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] numbersInBubbles;

    [SerializeField] private RectTransform[] bubbles;

    [SerializeField] private SpriteRenderer[] numbersInBoxes;
    
    [SerializeField] private int currentNumber = 1;

    [SerializeField] private GameObject[] objectsToDisable;
    [SerializeField] private GameObject[] objectsToEnable;
    
    private Sequence bubblePop;

    public void CheckOrder(int numberToCheck)
    {
        numbersInBubbles[numberToCheck - 1].transform.DOScale(new Vector3(0, 0, 0), 0.2f);  
        if (numberToCheck == currentNumber)
        {
            bubblePop = DOTween.Sequence();
            bubblePop.Append(bubbles[numberToCheck-1].DOScale(new Vector3(1.5f,1.5f,0f), 0.2f))
                .Append(bubbles[numberToCheck-1].DOScale(new Vector3(0f,0f,0f), 0.2f));
            
            currentNumber++;

            numbersInBoxes[numberToCheck - 1].transform.DOScale(new Vector3(0.3f, 0.3f, 0f), 0.15f);
        }
        else
        {
            numbersInBubbles[numberToCheck - 1].transform.DOScale(new Vector3(0.3f, 0.3f, 0), 0.2f); 
        }
    }

    private void ObjectsActivation()
    {
        for (int i = 0; i < objectsToDisable.Length; i++)
        {
            objectsToDisable[i].SetActive(false);
        }
        
        for (int i = 0; i < objectsToEnable.Length; i++)
        {
            objectsToEnable[i].SetActive(true);
        }
    }

    public void ObjectsControl()
    {
        
        DOVirtual.DelayedCall(1.5f, ObjectsActivation);
    }
    
}
