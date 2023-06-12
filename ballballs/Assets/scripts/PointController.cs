using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    public GameObject camera;

    [SerializeField]
    private PointGeneratorScript pointgen;

    public ParticleSystem explosion; 
    void Start()
    {
        pointgen = GameObject.Find("PointGenerator").GetComponent<PointGeneratorScript>();
        camera = GameObject.Find("Main Camera");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Boundaries"))
        {
            // Get the contact point of the collision
            ContactPoint2D contact = collision.contacts[0];

            // Instantiate the particle system at the contact point
            ParticleSystem newExplosion = Instantiate(explosion, contact.point, Quaternion.identity);

            pointgen.playPointSound(1);

            // Play the particle system
            newExplosion.Play();
            camera.GetComponent<CameraShaker>().Shake();


            // Destroy the particle system after its duration has elapsed
            Destroy(newExplosion.gameObject, newExplosion.main.duration);

            Destroy(gameObject);
            PointGeneratorScript.OnPointDestroyed();
            if (scoreScript.score > 0)
            {
                scoreScript.score--;
            }
        }
    }
    public void Destroyer()
    {
        Destroy(gameObject);
        pointgen.playPointSound(2);
    }
}

