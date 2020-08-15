using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private string _ballText, _correctBallText;
    private Button _button;


    private void Start()
    {
        _button = gameObject.GetComponent<Button>();
    }

    public void OnBallClick()
    {  
        _ballText = gameObject.GetComponentInChildren<TextMeshProUGUI>().text;
        _correctBallText = StadiumManager.Instance.correctBall.GetComponentInChildren<TextMeshProUGUI>().text;
        if (_ballText == _correctBallText)
        {
            StartCoroutine(PunchBallAnim());
        }
    }

    private IEnumerator PunchBallAnim()
    {
        WaitForSeconds wait = new WaitForSeconds( 1f ) ;
        // Shows balls;
        gameObject.transform.DOPunchScale(new Vector3 (1, 1, 1), 0.5f);
        yield return wait;
        
        _button.interactable = false;
        GameSceneManager.Instance.ChangeScene();
        
       
    }
}
