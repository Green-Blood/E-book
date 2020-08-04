using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CloudDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 _startPosition;
    private CanvasGroup _canvasGroup;
    public bool Dragged { get; set; }


    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        
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
        gameObject.transform.DOScale(0, 0.5f);
        yield return new WaitForSeconds(1f);
        //_canvasGroup.alpha = 1f;
        yield return  new WaitForSeconds(1f);
        gameObject.transform.DOScale(1, 0.5f);
        transform.position = _startPosition;
    }
}
