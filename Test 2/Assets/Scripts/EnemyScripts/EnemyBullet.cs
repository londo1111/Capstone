using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 2;

    void Start()
    {
        transform.LookAt(Player);
    }

    void Update()
    {
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            SceneManager.LoadScene("Level 1");
        }
    }
}
