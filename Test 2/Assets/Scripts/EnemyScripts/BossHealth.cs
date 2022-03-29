using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int healthInitial = 3;  // The Enemy's health at the start
    private int healthCurrent;  // The Enemy's health right now

    public Transform Player;
    public int MoveSpeed = 2;
    public float stoppingDistance;

    public float offset;

    BossPhases refScript;

    private Vector2 targetPos;
    private Vector2 thisPos;
    private float angle;

    private float enemyRange = 10;

    void Start()
    {
        ResetHealth();  // Initialiase the Enemy's current health

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        refScript = GetComponent<BossPhases>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    public void ResetHealth()   // Sets the Enemy's current health back to its initial value
    {
        healthCurrent = healthInitial; // Initialise the Enemy's current health
    }

    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        if (healthCurrent == 1)
        {
            Destroy(refScript);

            //transform.LookAt(Player);
            if (Vector2.Distance(transform.position, Player.position) < enemyRange)
            {
                if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
                }
            }
        }
        if (healthCurrent <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Kill the Enemy
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            print(collision);
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    //Do the Damage
    /*public Player PlayerScript;

    //Damage the player
    public void DamagePlayer(int amountDamage)
    {
    if (PlayerScript != null)
    {
    PlayerScript.CauseDamage(amountDamage);
    }
    }

    //Get the player's health, returns -1 if we are missing a reference to the player
    public int GetPlayerHealth()
    {
    int returnValue = -1;
    if (PlayerScript != null)
    {
    returnValue = PlayerScript.GetHealth();
    }
    return returnValue;
    }*/
}
