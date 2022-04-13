using System.Collections;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform Player;
    private PlayerHealth playerHealth;

    public float MoveSpeed = 2;
    public float stoppingDistance;

    public float offset;

    private const float enemyRange = 10;

    private bool canDamage = true;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && canDamage)
        {
            StartCoroutine(Damage());
        }
    }

    private IEnumerator Damage()
    {
        canDamage = false;
        playerHealth.TakeDamage(20);

        yield return new WaitForSeconds(0.5f);

        canDamage = true;
    }

    /*
    void LateUpdate()
    {
        targetPos = Player.position;
        thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + offset));
    }
    */
}

