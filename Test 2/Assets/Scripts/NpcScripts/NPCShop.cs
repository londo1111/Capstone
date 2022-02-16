using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject canvas;

    private MoneyManager moneyManager;

    private bool triggeringPlayer;
    private bool shopEnabled;

    // the items the player buys and how much they cost to buy
    [SerializeField] 
    private GameObject item;
    [SerializeField]
    private int price;
    [SerializeField] 
    private GameObject item2;
    [SerializeField]
    private int price2;
    [SerializeField] 
    private GameObject item3;
    [SerializeField]
    private int price3;

    private void Start()
    {
        moneyManager = player.GetComponent<MoneyManager>();
    }

    // the canavs that shows the image of the item being sold
    public void Update()
    {
        InputShopCheck();
    }

    private void InputShopCheck()
    {
        if (shopEnabled)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }

        /*if (triggeringPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))  // player presses E and it enables the shop
            {
                shopEnabled = !shopEnabled;
            }
        }*/
    }

    public void ShopItemClick()
    {
        Debug.Log("me press");
        if (shopEnabled)
        {
            SellItem();
        }
    }

    // how the npc sells the item and what happens when you don't have enough money
    public void SellItem()
    {
        if (moneyManager.CurrentCoins >= price)
        {

            Transform itemSpawned = Instantiate(item.transform, player.transform.position, Quaternion.identity);
            itemSpawned.gameObject.SetActive(false);
            itemSpawned.parent = player.transform;
            moneyManager.RemoveCoins(price);
        }
        else
        {
            print("Sorry you seem to not have enough money to buy this ...try asking someone for a loan");
        }
    }

    // player enters the area that enables the npc to start selling items
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopEnabled = true;
            triggeringPlayer = true;
        }
    }

    // player exits the area
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            triggeringPlayer = false;
            shopEnabled = false;
        }
    }
}

