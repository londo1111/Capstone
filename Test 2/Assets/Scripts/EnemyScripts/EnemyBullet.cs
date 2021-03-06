using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    /*
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

    */
    public Transform Player;
    public int MoveSpeed = 2;
    public float stoppingDistance;

    public float offset;

    private Vector2 targetPos;
    private Vector2 thisPos;
    private float angle;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    void Update()
    {
        //transform.LookAt(Player);
        if (Vector2.Distance(transform.position, Player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.position, MoveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }

        if (collision.transform.tag == "PlayerBullet")
        {
            Destroy(gameObject);
            Debug.Log("bap");
        }
    }

    void LateUpdate()
    {
        targetPos = Player.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
}
    

