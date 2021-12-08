using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNPC : MonoBehaviour
{

    public Button button;
    public GameObject player;
    public GameObject canvas;

    private bool triggeringPlayer;
    private bool shopEnabled;


    public GameObject item;
    public int price;


    public void start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    public void Update()
    {
        if (shopEnabled)
            canvas.SetActive(true);
        else
            canvas.SetActive(false);

        if (triggeringPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
                shopEnabled = !shopEnabled;
        }
    }

    void TaskOnClick()
    {
        if (shopEnabled)
        {
            Sell();
        }
    }


    public void Sell()
    {
        if(player.GetComponent<Placeholder>().money >= price)
        {

            Transform itemSpawned = Instantiate(item.transform, player.transform.position, Quaternion.identity);
            itemSpawned.gameObject.SetActive(false);
            itemSpawned.parent = player.transform;
            player.GetComponent<Placeholder>().money -= price;

        }
        else
        {
            print("Sorry you seem to not have enough money to buy this... maybe try asking for a loan");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringPlayer = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringPlayer = false;
        }
    }
}
