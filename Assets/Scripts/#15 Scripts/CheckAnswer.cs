using TMPro;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
     
    [SerializeField] private GameObject gate;
    [SerializeField] private TextMeshProUGUI[] windowsText;
    
    private int _answer;
    private int _correctAnswers;
    
    // Hope this shit will be changed
    private void Start()
    {
        _answer = int.Parse(gate.GetComponentInChildren<TextMeshProUGUI>().text);
    }
    
    public void CheckCorrect()
    {
        // Hopefully this will be changed someday //
        // Checks first window with second, if correct updates. 
        if (int.Parse(windowsText[0].text) + int.Parse(windowsText[1].text)  == _answer)
        {
            _correctAnswers++;
        }
        if (int.Parse(windowsText[2].text) + int.Parse(windowsText[3].text)  == _answer)
        {
            _correctAnswers++;
        }
        if (int.Parse(windowsText[4].text) + int.Parse(windowsText[5].text)  == _answer)
        {
            _correctAnswers++;
        }
        
        if (_correctAnswers > 2)
        {
            // Here Should be the end of the game
            Debug.Log("Lox");
        }
    }
}
