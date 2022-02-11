using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossPhases : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 2;
    public int healthInitial = 10;  // The Enemy's health at the start
    private int healthCurrent;  // The Enemy's health right now

    void Update()
    {
        transform.LookAt(Player);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    void Start()
    {
        ResetHealth();  // Initialiase the Enemy's current health
    }

    public void ResetHealth()   // Sets the Enemy's current health back to its initial value
    {
        healthCurrent = healthInitial; // Initialise the Enemy's current health
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("Level 1");
        }
    }

    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        if (healthCurrent <= 5)
        {
            MoveSpeed = 10;
        }

        if (healthCurrent <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // Kill the Enemy
            Destroy(gameObject);
        }
    }
}
