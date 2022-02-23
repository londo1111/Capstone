using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI moneyText;

    [SerializeField]
    private int currentCoins = 0;
    public int CurrentCoins { get { return currentCoins; } }
    
    private void Start()
    {
        moneyText.text = "Coins: " + currentCoins.ToString();
    }

    public void AddCoins(int coinToAdd)
    {
        currentCoins += Mathf.Abs(coinToAdd);
        moneyText.text = "Coins: " + currentCoins;
    }

    public void RemoveCoins(int coinsToRemove)
    {
        currentCoins -= Mathf.Abs(coinsToRemove);
        moneyText.text = "Coins: " + currentCoins;
    }
}