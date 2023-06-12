using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerScript : MonoBehaviour
{

    public GameObject player;
    public float forceMultiplier;
    public float damping;

    public ParticleSystem explosion;


    private Rigidbody2D rb;

    void Start()
    {
        forceMultiplier = 4;
        damping = 1;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        rb.AddForce(direction * distance * forceMultiplier);
        rb.velocity *= Mathf.Clamp01(1.0f - damping * Time.deltaTime);
        rb.angularVelocity *= Mathf.Clamp01(1.0f - damping * Time.deltaTime);
    }
    public void GetDestroyed()
    {

        // Instantiate the particle system at the contact point
        ParticleSystem newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);

        // Play the particle system
        newExplosion.Play();

        // Destroy the particle system after its duration has elapsed
        Destroy(newExplosion.gameObject, newExplosion.main.duration);

        Destroy(gameObject);
    }
}
