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

    void Update()
    {
        transform.LookAt(Player);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    void Start()
    {
        ResetHealth();  // Initialiase the Enemy's current health
    }

    public void ResetHealth()   // Sets the Enemy's current health back to its initial value
    {
        healthCurrent = healthInitial; // Initialise the Enemy's current health
    }

    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        if (healthCurrent <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Kill the Enemy
            Destroy(gameObject);
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
