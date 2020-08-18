using DG.Tweening;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public void MovePlayer(Vector3 position, float timeToMove)
    {
        //transform.position = position;
        transform.DOMove(position, timeToMove);
    }
}
