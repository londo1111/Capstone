using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
    [SerializeField] [Range(0, 100)]
    private int currentHealth;

    [SerializeField]
    private Gradient healthBarColor;

    [SerializeField]
    private Image healthBar;
    [SerializeField]
    private TextMeshProUGUI healthTitle;

    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.color = healthBarColor.Evaluate((float)currentHealth / (float)maxHealth);
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= Mathf.Abs(amount);

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        UpdateHealthBar();
    }

    public void RestoreHealth(int amount)
    {
        currentHealth += Mathf.Abs(amount);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float newAmount = (float)currentHealth / (float)maxHealth;
        Color newColor = healthBarColor.Evaluate(newAmount);

        healthBar.fillAmount = newAmount;
        healthBar.color = newColor;
        healthTitle.color = newColor;
    }

    public void SetMaxHealth(int value)
    {
        maxHealth = value;
        UpdateHealthBar();
    }
}
