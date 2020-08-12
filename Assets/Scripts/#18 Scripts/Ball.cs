using DG.Tweening;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private string _ballText, _correctBallText;
     

    public void OnBallClick()
    {  
        _ballText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        _correctBallText = StadiumManager.Instance.correctBall.GetComponentInChildren<TextMeshProUGUI>().text;
        if (_ballText == _correctBallText)
        {
            gameObject.transform.DOPunchScale(new Vector3 (1, 1, 1), 0.5f);
        }
    }
}
