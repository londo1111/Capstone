using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    public int value;
    public MoneyManager theMM;

    // Start is called before the first frame update
    void Start()
    {
        theMM = FindObjectOfType<MoneyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            theMM.AddMoney(value);
            Destroy(gameObject);
        }
    }*/


}  