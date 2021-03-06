using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossPhases : MonoBehaviour
{
    public Transform Player;
    public int MoveSpeed = 2;
    public float stoppingDistance;

    public float offset;

    private Vector2 targetPos;
    private Vector2 thisPos;
    private float angle;

    private float enemyRange = 10;


    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        //transform.LookAt(Player);
        if (Vector2.Distance(transform.position, Player.position) < enemyRange)
        {
            if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
            }
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
}