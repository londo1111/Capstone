using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private Text moneyText;

    [SerializeField]
    private int currentCoins;
    public int CurrentCoins { get { return currentCoins; } }
    
    private void Start()
    {
        moneyText.text = "Coin: " + currentCoins.ToString();
    }

    public void AddCoins(int coinToAdd)
    {
        currentCoins += Mathf.Abs(coinToAdd);
        moneyText.text = "Coin: " + currentCoins;
    }

    public void RemoveCoins(int coinsToRemove)
    {
        currentCoins -= Mathf.Abs(coinsToRemove);
        moneyText.text = "Coin: " + currentCoins;
    }
}