using DG.Tweening;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator playerAnimator;

    public bool isInAir;
    
    private static readonly int JumpStart = Animator.StringToHash("JumpStart");
    private static readonly int Landed = Animator.StringToHash("Landed");

    public void MovePlayer(Vector3 position, float timeToMove)
    {
        var directionLeft = new Quaternion(0, 180,0,0 );
        var directionRight = new Quaternion(0, 0, 0,0);
        //transform.position = position;
        if (transform.position.x < position.x)
        {
            transform.rotation = directionRight;
        }
        else
        {
            transform.rotation = directionLeft;
        }
        
        transform.DOJump(new Vector3(position.x, position.y+1f, position.z), 1,1 ,timeToMove)
            .OnComplete((() =>
        {
            isInAir = false;
            playerAnimator.SetTrigger(Landed);
        })).SetEase(Ease.OutQuad);
        
        
        playerAnimator.SetTrigger(JumpStart);
        isInAir = true;
    }
}
