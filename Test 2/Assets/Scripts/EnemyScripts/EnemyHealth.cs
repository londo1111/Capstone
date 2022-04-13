using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private XPManager xpManager;

    [SerializeField]
    private int maxHealth = 100;
    private int currentHealth;

    [SerializeField] [Min(10f)]
    private float xpKillValue;

    [SerializeField] [Min(5f)]
    private float xpDmgValue;

    private Image healthBar;

    [SerializeField]
    private GameObject goldPickup;

    [SerializeField]
    private Gradient barColor;

    [SerializeField]
    private bool isBoss = false;

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
        xpManager.AddToXPAmount(xpKillValue);

        if (goldPickup != null)
        {
            Instantiate(goldPickup, transform.position, Quaternion.identity);
        }

        if (isBoss)
        {
            GetComponent<BossMain>().Death();
        }
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
            xpManager.AddToXPAmount(xpDmgValue);
        }
    }
}
