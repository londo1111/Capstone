using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyText;
    public int currentCoin;
    
    // Start is called before the first frame update
    void Start()
    {
        
        if(PlayerPrefs.HasKey("CurrentMoney"))
        {
            currentCoin = PlayerPrefs.GetInt("CurrentMoney");
        } else {
            currentCoin = 0;
            PlayerPrefs.SetInt("Currentmoney", 0);
        }

        moneyText.text = "Coin: " + currentCoin;


        
    }

    // Update is called once per frame
    void Update()
    {
        

         void AddMoney(int coinToAdd)
        {
            currentCoin += coinToAdd;
            PlayerPrefs.SetInt("CurrentMoney", currentCoin);
            moneyText.text = "Coin: " + currentCoin;
        }
    }
}