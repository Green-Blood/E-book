using TMPro;
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private PlayerScript _thePlayerScript;
    private CameraScript _theCameraScript;
    private CoinGenerator _coinGenerator;
    
    private Vector3 _coinPosition;

    private void Start()
    {
        _coinPosition = gameObject.transform.position;
        
        _thePlayerScript = PlayerData.instance.thePlayerScript;
        _theCameraScript = PlayerData.instance.theCameraScript;
        _coinGenerator = PlayerData.instance.coinGenerator;

    }

    public void OnCoinClick()
    {
        if (_coinGenerator.GetCoinCount() !=
            int.Parse(gameObject.GetComponentInChildren<TextMeshProUGUI>().text) ||
            _thePlayerScript.isInAir) return;
        
        
        _thePlayerScript.MovePlayer(_coinPosition, 1);
        _theCameraScript.MoveCamera(_coinPosition,  1);
        
        _coinGenerator.UpdateCoinCount();
        gameObject.SetActive(false);
    }
}
