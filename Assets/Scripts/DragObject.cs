using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;


public class DragObject : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public string tagObject;
    public SpriteRenderer targetPointSprite;

    private const float TimeTween = 0.3f;

    private Vector3 _initialPosition;

    private Collider2D _collider2D;

    private Tween _returnTween, _pasteTween;
    private Sequence _pasteSequence;

     private void Start()
    {
        TakeProperties();
    }
    private void TakeProperties()
    {
        _collider2D = GetComponent<Collider2D>();
        
        _initialPosition = transform.localPosition;
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        DragController.FollowTouchOffset(transform, eventData.pointerId);
    }

   void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector3 destination = DragController.GetTouchWorldPosition(eventData.pointerId);
        RaycastHit2D hit2D;

        bool success = DragController.RaycastDetect(tagObject, destination, out hit2D);
        if (success)
            PasteObject();
        else
            ReturnCandy();
        
    }
   
    private void PasteObject()
    {
        targetPointSprite.transform.GetComponent<PositionProperty>().isTaken = true;
        _collider2D.enabled = false;
        
        /*_pasteTween = */
        _pasteSequence.Append(
            
        transform.DOMove(targetPointSprite.gameObject.transform.position, TimeTween)
        .OnComplete(() =>
        {
            transform.SetParent(targetPointSprite.gameObject.transform);
            transform.localPosition = Vector3.zero;
            
            transform.localScale=Vector3.one;
        }));
        
        _pasteSequence.Append(transform.DOScale(Vector3.zero, 0.5f));
    }

    private void ReturnCandy()
    {

        _returnTween = DOTween.Sequence()
            .Append(transform.DOShakePosition(TimeTween, 0.5f, 30, 0f))
            .Append(transform.DOLocalMove(_initialPosition, TimeTween).SetEase(Ease.InBack));
    }
}