using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed;
    public Rigidbody2D rb;

    private Vector2 MoveDirection;
    private bool facingRight;
    private float px;
    private float py;

    private void Start()
    {
        px = transform.position.x;
        py = transform.position.y;

    }

    void Update()
    {

        ProcessInputs();


    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float MoveX = Input.GetAxisRaw("Horizontal");
        float MoveY = Input.GetAxisRaw("Vertical");

        MoveDirection = new Vector2(MoveX, MoveY).normalized;

        if (facingRight == true && MoveX > 0)
        {
            flip();
        }
        else if (facingRight == false && MoveX < 0)
        {
            flip();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(MoveDirection.x * MoveSpeed, MoveDirection.y * MoveSpeed);
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LFish") || collision.CompareTag("BFish"))
        {
            Destroy(gameObject);
        }
    }
}
