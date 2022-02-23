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

    private MoneyManager moneyManager;

    private bool shopEnabled;

    // the items the player buys and how much they cost to buy
    [SerializeField] 
    private GameObject item;
    [SerializeField] 
    private GameObject item2;
    [SerializeField] 
    private GameObject item3;

    private void Start()
    {
        shopUI.SetActive(false);
        shopEnabled = false;
        moneyManager = player.GetComponent<MoneyManager>();
    }

    // how the npc sells the item and what happens when you don't have enough money
    public void SellItem(int price)
    {
        if (!shopEnabled)
        {
            return;
        }

        Debug.Log(price);

        if (moneyManager.CurrentCoins >= price)
        {
            Transform itemSpawned = Instantiate(item.transform, player.transform.position, Quaternion.identity);
            itemSpawned.gameObject.SetActive(false);
            itemSpawned.parent = player.transform;
            moneyManager.RemoveCoins(price);
        }
    }

    // player enters the area that enables the npc to start selling items
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopEnabled = true;
            shopUI.SetActive(true);
        }
    }

    // player exits the area
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopEnabled = false;
            shopUI.SetActive(false);
        }
    }
}

