using DG.Tweening;
using UnityEngine;

public class DragController : MonoBehaviour
{
    public static Camera currentCamera;

    private static PositionProperty _colliderObjectProperty;
    private void Start()
    {
        TakeCamera();
    }

    public void TakeCamera()
    {
        currentCamera = Camera.main;
    }

    public static Vector2 GetTouchWorldPosition(int pointerId = 0)
    {
        Vector2 screenPoint;
        screenPoint = Input.mousePosition;
        
        return currentCamera.ScreenToWorldPoint(screenPoint);
    }

    public static void FollowTouchOffset(Transform transform,int pointerId = 0)
    {
        Vector2 destination = GetTouchWorldPosition(pointerId);
        transform.DOMove(destination, 0.3f);
    }

    public static bool RaycastDetect(string side, Vector3 rayStartPoint, out RaycastHit2D hit2D)
    {
        Vector2 rayPoint = rayStartPoint;
    
        RaycastHit2D[] hits2D = Physics2D.RaycastAll(rayPoint, Vector3.forward);
    
        int length = hits2D.Length;
        for (int j = 0; j < length; j++)
        {
            if (!CheckDetection(side, hits2D[j].collider)) continue;
    
            _colliderObjectProperty.FinalScale();
            hit2D = hits2D[j];
            return true;
        }
    
        hit2D = new RaycastHit2D();
        return false;
    }

    private static bool CheckDetection(string side, Collider2D colliderObject)
    {
        _colliderObjectProperty = colliderObject.transform.GetComponent<PositionProperty>();
        
        if ( _colliderObjectProperty != null)
        {
            return side == _colliderObjectProperty.tag;
        }
    
        return side.Equals(colliderObject.name);
    }
}
