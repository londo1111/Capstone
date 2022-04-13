using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private XPManager xpManager;

    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] [Min(10)]
    private float xpValue;

    private Image healthBar;

    [SerializeField]
    private GameObject goldPickup;

    [SerializeField]
    private Gradient barColor;

    private void Awake()
    {
        xpManager = FindObjectOfType<XPManager>();
        healthBar = transform.Find("HealthCanvas").Find("HealthBar").GetComponent<Image>();
        currentHealth = maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= Mathf.Abs(amount);

        if (currentHealth <= 0)
        {
            PlayerDeath();
        }

        UpdateHealthBar();
    }

    private void PlayerDeath()
    {
        xpManager.AddToXPAmount(xpValue);

        Instantiate(goldPickup, transform.position, Quaternion.identity);
        Destroy(gameObject);
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
            Damage(SkillTreeManager.BulletDamage);
        }
    }
}
