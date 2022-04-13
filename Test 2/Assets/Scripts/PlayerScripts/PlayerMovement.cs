using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Camera cam;

    Vector2 mousePos;
    Vector2 movement;

    private readonly Vector2[] spawnPositions =
    {
        new Vector2(-2.47f, -33.77f), // Level 1
        new Vector2(-8.9f, -0.5f), // Level 2
        new Vector2(-20.1f, -1.67f), // Level 3
        new Vector2(-64.05f, -24.91f), // Level 4
        new Vector2(-12.12f, -0.95f), // Level 5
        new Vector2(107.9f, 101f), // Level 6
        new Vector2(0f, 0f), // Level 7
        new Vector2(-5f, -0.4f), // Level 8
        new Vector2(-51.11f, -2.4f) // Level 9
    };

    /* Variables */

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void Start()
    {
        int curIndex = SceneManager.GetActiveScene().buildIndex;

        //if (startingPosition != null)
        //{
        //    transform.position = startingPosition.initialValue;
        //}

        switch (curIndex)
        {
            case 1:
                transform.position = spawnPositions[0];
                break;

            case 2:
                transform.position = spawnPositions[1];
                break;

            case 3:
                transform.position = spawnPositions[2];
                break;

            case 4:
                transform.position = spawnPositions[3];
                break;

            case 5:
                transform.position = spawnPositions[4];
                break;

            case 6:
                transform.position = spawnPositions[5];
                break;

            case 7:
                transform.position = spawnPositions[6];
                break;

            case 8:
                transform.position = spawnPositions[7];
                break;

            case 9:
                transform.position = spawnPositions[8];
                break;
        }
    }
}

