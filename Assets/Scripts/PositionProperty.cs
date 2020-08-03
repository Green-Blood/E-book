using DG.Tweening;
using UnityEngine;

public class PositionProperty : MonoBehaviour {

    public string tag;

    [HideInInspector] public Transform positionPoint;
    public bool isTaken = false;

    private void Awake()
    {
        positionPoint = transform;
    }

    public void FinalScale()
    {
        transform.DOScale(Vector3.zero, 0.5f);
    }
}