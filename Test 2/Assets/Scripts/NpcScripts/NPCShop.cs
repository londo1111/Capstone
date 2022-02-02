using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShop : MonoBehaviour
{

    public Button button;
    public GameObject player;
    public GameObject canvas;

    private bool triggeringPlayer;
    private bool shopEnabled;

    // the items the player buys and how much they cost to buy
    public GameObject item;
    public int price;
    public GameObject item2;
    public int price2;
    public GameObject item3;
    public int price3;
    public GameObject item4;
    public int price4;
    public GameObject item5;
    public int price5;
    public GameObject item6;
    public int price6;
    public GameObject item7;
    public int price7;

    public void start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    // the canavs that shows the image of the item being sold
    public void Update()
    {
        if (shopEnabled)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }

        if (triggeringPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))  // player presses E and it enables the shop
            {
                shopEnabled = !shopEnabled;
            }
        }
    }

    void TaskOnClick()
    {
        if (shopEnabled)
        {
            Sell();
        }
    }

    // how the npc sells the item and what happens when you don't have enough money
    public void Sell()
    {
        if (player.GetComponent<MoneyManager>().currentCoin >= price)
        {

            Transform itemSpawned = Instantiate(item.transform, player.transform.position, Quaternion.identity);
            itemSpawned.gameObject.SetActive(false);
            itemSpawned.parent = player.transform;
            player.GetComponent<MoneyManager>().currentCoin -= price;

        }
        else
        {
            print("Sorry you seem to not have enough money to buy this ...try asking someone for a loan");
        }
    }
    // player enters the area that enables the npc to start selling items
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringPlayer = true;
        }
    }
    // player exits the area
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringPlayer = false;
        }
    }
}

