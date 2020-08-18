using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public void MoveCamera(Vector3 coinPosition, float moveTime)
    {
        if (coinPosition.y > transform.position.y) transform.DOMoveY(coinPosition.y, moveTime);
    }
}
