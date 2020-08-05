using System.Collections;
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
    {
        transform.position = eventData.position;
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = true;
        StartCoroutine(Scale());
    }

    
    private IEnumerator Scale()
    {
        // Scales down in 1 second
        gameObject.transform.DOScale(0, 0.5f);
        yield return new WaitForSeconds(1f);
        // Scales up in 1 sec
        yield return  new WaitForSeconds(1f);
        gameObject.transform.DOScale(1, 0.5f);
        transform.position = _startPosition;
    }
}
