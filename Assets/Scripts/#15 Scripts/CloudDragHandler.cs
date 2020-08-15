﻿using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloudDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _startPosition;
    private CanvasGroup _canvasGroup;
    // Checks if cloud was already dragged or not 
    public bool Dragged { get; set; }
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Gets start position of the cloud
        _startPosition = transform.position;
        //_canvasGroup.alpha = .6f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    { transform.position = eventData.position; }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        StartCoroutine(ScaleCloud());
    }

    
    private IEnumerator ScaleCloud()
    {
        var wait = new WaitForSeconds( 1f ) ;
        
        // Scales down in 0.5 second, and wait for 1 sec
        gameObject.transform.DOScale(0, 0.5f);
        yield return wait;
        
        // Scales up in 0.5 sec in the start position
        gameObject.transform.DOScale(1, 0.5f);
        transform.position = _startPosition;
        
    }
}
