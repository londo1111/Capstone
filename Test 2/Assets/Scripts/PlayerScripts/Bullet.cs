using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeDestroy;
    public GameObject hitEffect;

    private AudioSource audioSrc;

    private bool hit = false;

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Background" || hit) { return; }
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);

        /*
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        */
        hit = true;

        GetComponent<SpriteRenderer>().enabled = false;

        audioSrc.Play();
        Destroy(gameObject, audioSrc.clip.length);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hit) { return; }

        hit = true;

        GetComponent<SpriteRenderer>().enabled = false;

        audioSrc.Play();
        Destroy(gameObject, audioSrc.clip.length);
    }
}
