using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFollowerScript : MonoBehaviour
{

    public GameObject player;
    public float forceMultiplier;
    public float damping;

    private Rigidbody2D rb;

    void Start()
    {
        player = GameObject.Find("Menu player");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 direction = player.transform.position - transform.position;
        float distance = direction.magnitude;
        direction.Normalize();

        rb.AddForce(direction * distance * forceMultiplier);
        rb.velocity *= Mathf.Clamp01(1.0f - damping * Time.deltaTime);
        rb.angularVelocity *= Mathf.Clamp01(1.0f - damping * Time.deltaTime);
    }
}
