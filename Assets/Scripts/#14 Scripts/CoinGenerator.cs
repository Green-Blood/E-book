using TMPro;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
     public GameObject[] coins;
     private int _coinCount = 1;
     public int GetCoinCount() => _coinCount;
     private void Start()
     {
          for (int i = 1; i < coins.Length + 1; i++)
          {
               coins[i - 1].GetComponentInChildren<TextMeshProUGUI>().text = i.ToString();
          }
     }

     public void UpdateCoinCount()
     {
          _coinCount++;
     }
}
