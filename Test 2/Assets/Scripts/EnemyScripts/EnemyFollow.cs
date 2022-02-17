using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
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

        if (collision.transform.tag == "PlayerBullet")
        {
            Destroy(gameObject);
        }
    }
}

