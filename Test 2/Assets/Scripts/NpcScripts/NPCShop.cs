using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject shopUI;

    private Transform itemSpawn;

    private MoneyManager moneyManager;

    private bool shopEnabled;

    [Header("Shop Items")]

    [SerializeField] 
    private GameObject item01;
    [SerializeField] 
    private GameObject item02;
    [SerializeField] 
    private GameObject item03;

    private void Start()
    {
        shopUI.SetActive(false);
        shopEnabled = false;
        moneyManager = player.GetComponent<MoneyManager>();
        itemSpawn = transform.Find("ItemSpawn");
    }

    // how the npc sells the item and what happens when you don't have enough money
    public void SellItem(int price)
    {
        if (!shopEnabled)
        {
            return;
        }

        Debug.Log(price);

        if (MoneyManager.CurrentCoins >= price)
        {
            string newItem;

            switch (price)
            {
                case 25:
                    newItem = "Item1";
                    break;

                case 40:
                    newItem = "Item2";
                    break;

                case 60:
                    newItem = "Item3";
                    break;

                default:
                    return;
            }

            SummonItem(newItem);
            moneyManager.RemoveCoins(price);
        }
    }

    private void SummonItem(string item)
    {
        switch (item) // Goes through all possible cases of item variations, instantiates specific item as a result
        {
            case "Item1":
                Instantiate(item01, itemSpawn.position, Quaternion.identity);
                break;

            case "Item2":
                Instantiate(item02, itemSpawn.position, Quaternion.identity);
                break;

            case "Item3":
                Instantiate(item03, itemSpawn.position, Quaternion.identity);
                break;

            default:
                Debug.LogWarning("No matching item case");
                break;
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Checks if player enters shop trigger box, enables UI if so
        {
            shopEnabled = true;
            shopUI.SetActive(true);
        }
    }

    // player exits the area
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Checks if player leaves shop trigger box, disables UI if so
        {
            shopEnabled = false;
            shopUI.SetActive(false);
        }
    }
}

