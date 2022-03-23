using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    private Image healthBar;
    [SerializeField]
    private GameObject goldPickup;

    [SerializeField]
    private Gradient barColor;

    private void Awake()
    {

        healthBar = transform.Find("HealthCanvas").Find("HealthBar").GetComponent<Image>();
        currentHealth = maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= Mathf.Abs(amount);

        if (currentHealth <= 0)
        {
            Instantiate(goldPickup, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float newFill = (float)currentHealth / (float)maxHealth;
        Color newColor = barColor.Evaluate(newFill);

        healthBar.fillAmount = newFill;
        healthBar.color = newColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            Damage(10);
        }
    }
}
