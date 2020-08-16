using TMPro;
using UnityEngine;

public class CheckAnswer : MonoBehaviour
{
     
    [SerializeField] private GameObject gate;
    [SerializeField] private TextMeshProUGUI[] windowsText;
    [SerializeField] private NumberGenerator numberGenerator;

    private int _answer;
    private void Start()
    {
        _answer = int.Parse(gate.GetComponentInChildren<TextMeshProUGUI>().text);
         
    }

    public bool CheckCorrect(int correctAnswersLeft)
    {
        var correctAnswers = 0;

        // Checks first window with second, if correct updates. 
        if (!CorrectText(windowsText[0].text, windowsText[1].text)) 
        {
            
            if (IsAnswerCorrect(windowsText[0].text, windowsText[1].text))
            {
                correctAnswers++;
            }
            else
            {
                numberGenerator.ResetClouds();
                windowsText[0].text = ""; windowsText[1].text = "";
            }
        }

        if (!CorrectText(windowsText[2].text, windowsText[3].text))
        {
            if (IsAnswerCorrect(windowsText[2].text, windowsText[3].text)) 
            {
                correctAnswers++;
            }
            else
            {
                numberGenerator.ResetClouds();
                windowsText[2].text = ""; windowsText[3].text = "";
            }
        }
        
        if (!CorrectText(windowsText[4].text, windowsText[5].text))
        {
            if (IsAnswerCorrect(windowsText[4].text, windowsText[5].text))
            {
                correctAnswers++;
            }
            else
            {
                numberGenerator.ResetClouds();
                windowsText[4].text = ""; windowsText[5].text = "";
            } 

        }

        return correctAnswers >= correctAnswersLeft;
    }
    
    // Check for correct Text provided
    private bool CorrectText(string s1, string s2)
    { return s1 == "" || s2 == ""; }

    // Check for correct Answer
    private bool IsAnswerCorrect(string s1, string s2)
    { return int.Parse(s1) + int.Parse(s2) == _answer; }

}
