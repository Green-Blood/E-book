using TMPro;
using UnityEngine;


public class NumberGenerator : MonoBehaviour
{

    [Header("UI Objects")] 
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject[] clouds;
    
    
    [Header("Parameters")]
    [SerializeField] private int numberToGenerate;
    
    public void Start()
    {
        GenerateNumber(numberToGenerate);
        gate.GetComponentInChildren<TextMeshProUGUI>().text = numberToGenerate.ToString();
    }

    private void GenerateNumber(int number)
    {
        foreach (var cloud in clouds)
        {
            cloud.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(1, number).ToString();
        }
    }
}
