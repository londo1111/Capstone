using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    private static float speed = 3f;

    private void Awake()
    {
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up, Space.Self);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
