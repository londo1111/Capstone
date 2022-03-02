using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    private MoneyManager moneyManager;

    [SerializeField] [Range(1, 100)] [Tooltip("How much money the pickup adds when picked up")]
    private int value = 5;

    private bool canPickup = true;

    private void Awake()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && canPickup)
        {
            canPickup = false;
            moneyManager.AddCoins(value);
            Destroy(gameObject);
        }
    }
}  