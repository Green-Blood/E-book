using TMPro;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
     
    [SerializeField] private GameObject gate;
    [SerializeField] private TextMeshProUGUI[] windowsText;
    [SerializeField] private int correctAnswersLeft;
    
    private int _answer;
    private void Awake()
    {
        _answer = int.Parse(gate.GetComponentInChildren<TextMeshProUGUI>().text);
    }

    public void CheckCorrect()
    {
        var correctAnswers = 0;
        var answerCount = 0;

        // Checks first window with second, if correct updates. 
        if (!CorrectText(windowsText[0].text, windowsText[1].text)) {
            if (IsAnswerCorrect(windowsText[0].text, windowsText[1].text))
                correctAnswers++; 
            answerCount++;
        }

        if (!CorrectText(windowsText[2].text, windowsText[3].text))
        {
            if (IsAnswerCorrect(windowsText[2].text, windowsText[3].text)) 
                correctAnswers++; 
            answerCount++;
        }
        
        if (!CorrectText(windowsText[4].text, windowsText[5].text))
        {
            if (IsAnswerCorrect(windowsText[4].text, windowsText[5].text))
                correctAnswers++;  
            answerCount++;
        }
        
        if (correctAnswers >= correctAnswersLeft)
        {
            // Here Should be the end of the game
            GameSceneManager.Instance.WinGame();
        }
        else if(answerCount >= 3)
        {
            GameSceneManager.Instance.ResetGame();
        }

         
    }
    
    // Check for correct Text provided
    private bool CorrectText(string s1, string s2)
    { return s1 == "" || s2 == ""; }

    // Check for correct Answer
    private bool IsAnswerCorrect(string s1, string s2)
    { return int.Parse(s1) + int.Parse(s2) == _answer; }

}
