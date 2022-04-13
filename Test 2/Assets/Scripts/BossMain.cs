using System.Collections;
using UnityEngine;

public class BossMain : MonoBehaviour
{
    private Transform pivot;
    private Transform player;
    private Transform projShooter;

    [SerializeField]
    private GameObject levelExit;

    [SerializeField]
    private GameObject bossProjectile;

    [SerializeField]
    private float moveSpeed = 3f;

    private bool attacking = false;

    private void Awake()
    {
        pivot = transform.parent;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        projShooter = transform.GetChild(1);

        StartCoroutine(AttackWait());
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (!attacking)
        {
            pivot.position = Vector2.MoveTowards(pivot.position, player.position, moveSpeed * Time.deltaTime);
        }
    }

    private IEnumerator AttackWait()
    {
        float wait = Random.Range(15f, 25f);

        yield return new WaitForSeconds(wait);

        StartCoroutine(SpinAttack());
    }

    private IEnumerator SpinAttack()
    {
        attacking = true;

        for (int i = 0; i < 20; i++)
        {
            projShooter.RotateAround(pivot.position, Vector3.forward, 18f);
            Instantiate(bossProjectile, projShooter.transform.position, projShooter.rotation);
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(2f);

        attacking = false;

        StartCoroutine(AttackWait());
    }

    public void Death()
    {
        levelExit.SetActive(true);
        Destroy(gameObject);
    }
}
