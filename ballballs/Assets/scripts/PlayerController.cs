using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManagerScript gameManager;
    float leftEdge;
    float rightEdge;
    float topEdge;
    float bottomEdge;

    public GameObject camera;

    //public GameObject text;

    public ParticleSystem explosion;


    private float smoothTime = 0.1f;
    private Vector2 velocity = Vector2.zero;
    public float moveSpeed = 8f;
    private Rigidbody2D rb2D;
    private Vector2 movement;

    public GameObject follower;

    void Start()
    {
        camera = GameObject.Find("Main Camera");

        gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        follower = GameObject.Find("Follower");
        rb2D = GetComponent<Rigidbody2D>();
        leftEdge = -(Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height));
        rightEdge = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        topEdge = Camera.main.orthographicSize;
        bottomEdge = -Camera.main.orthographicSize;
        Debug.Log("top: " + topEdge + "bottom: " + bottomEdge + "right: " + rightEdge + "left: " + leftEdge + "\n");

    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

    }
    void FixedUpdate()
    {
        Vector2 targetVelocity = movement * moveSpeed;
        //smooth
        //rb2D.velocity = Vector2.SmoothDamp(rb2D.velocity, targetVelocity, ref velocity, smoothTime);
        //sharp
        rb2D.MovePosition(rb2D.position + movement * moveSpeed * Time.fixedDeltaTime);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collided with: " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {

            ContactPoint2D contact = collision.contacts[0];

            ParticleSystem newExplosion = Instantiate(explosion, contact.point, Quaternion.identity);

            newExplosion.Play();


            camera.GetComponent<CameraShaker>().Shake();


            Destroy(newExplosion.gameObject, newExplosion.main.duration);
            follower.GetComponent<FollowerScript>().GetDestroyed();

            Destroy(gameObject);


            Debug.Log("GAME OVER TIME!");
            gameManager.GameOver();

            
        }
    }
}
