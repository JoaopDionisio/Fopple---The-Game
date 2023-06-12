using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MenuPlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float bounceForce = 10f;

    private Rigidbody2D rb;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = GetRandomDirection();
        rb.velocity = direction * moveSpeed;
    }

    void FixedUpdate()
    {
        Vector2 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0 || pos.x > 1)
        {
            rb.velocity = new Vector2(-rb.velocity.x, rb.velocity.y);
        }

        if (pos.y < 0 || pos.y > 1)
        {
            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 normal = collision.contacts[0].normal;
        Vector2 bounceDirection = Vector2.Reflect(direction, normal);
        rb.velocity = bounceDirection * bounceForce;
        direction = rb.velocity.normalized;
    }

    private Vector2 GetRandomDirection()
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        return new Vector2(x, y).normalized;
    }
}