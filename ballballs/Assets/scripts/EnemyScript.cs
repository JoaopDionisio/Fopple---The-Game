using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public ParticleSystem explosion;

    public GameObject camera;
    public GameObject EnemyGen;

    public static float speed = 10.0f;
    public Vector2 direction;

    float leftEdge;
    float rightEdge;
    float topEdge;
    float bottomEdge;

    public float rotationSpeed = 100f;

    void Start()
    {
        camera = GameObject.Find("Main Camera");
        EnemyGen = GameObject.Find("EnemyGenerator");

        leftEdge = -(Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height));
        rightEdge = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        topEdge = Camera.main.orthographicSize;
        bottomEdge = -Camera.main.orthographicSize;

        // Set initial rotation to face the direction of movement
        transform.rotation = Quaternion.LookRotation(Vector3.forward, direction);
    }

    void Update()
    {
        // Move the enemy in its current direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        // Rotate the enemy around the z-axis
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        // Destroy the enemy if it goes off screen
        if (gameObject.transform.position.x > rightEdge + 10f || gameObject.transform.position.x < leftEdge - 10f || gameObject.transform.position.y > topEdge + 10f || gameObject.transform.position.y < bottomEdge - 10f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Follower"))
        {
            // Get the contact point of the collision
            ContactPoint2D contact = collision.contacts[0];

            // Instantiate the particle system at the contact point
            ParticleSystem newExplosion = Instantiate(explosion, contact.point, Quaternion.identity);

            EnemyGen.GetComponent<EnemyGeneratorScript>().playEnemySound(1);
            // Play the particle system
            newExplosion.Play();

            camera.GetComponent<CameraShaker>().Shake();
            // Destroy the particle system after its duration has elapsed
            Destroy(newExplosion.gameObject, newExplosion.main.duration);

            Destroy(gameObject);
        }
    }
}