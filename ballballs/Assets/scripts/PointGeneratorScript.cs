using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointGeneratorScript : MonoBehaviour
{
    public GameObject CameraObject;
    public GameObject PointPrefab;
    public float TimeToSpawn = 1f;
    public float spawnRadius = 2f;
    private float nextSpawnTime = 1f;
    static int pointCount = 0;
    public int maxPoints = 5;
    float leftEdge;
    float rightEdge;
    float topEdge;
    float bottomEdge;

    [SerializeField]
    private AudioClip [] Point_Sounds;
    [SerializeField]
    private AudioClip [] Destroyed_Point_Sounds;


    // Start is called before the first frame update
    void Start()
    {
        CameraObject = GameObject.Find("Main Camera");

        pointCount = 0;

        leftEdge = -(Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height));
        rightEdge = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        topEdge = Camera.main.orthographicSize;
        bottomEdge = -Camera.main.orthographicSize;

        nextSpawnTime = Time.time + 3f;
    }


    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime && pointCount < maxPoints)
        {
            nextSpawnTime = Time.time + TimeToSpawn;
            Vector3 spawnPosition = new Vector3(Random.Range(leftEdge + 1, rightEdge - 1), Random.Range(bottomEdge + 1, topEdge - 1), 0);

            Instantiate(PointPrefab, spawnPosition, Quaternion.identity);
            pointCount++;
        }
    }
    private Vector3 GetRandomPosition()
    {
        // Get a random position within the bounds of the screen
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(-5f, 5f);
        return new Vector3(x, y, 0f);
    }

    public static void OnPointDestroyed()
    {
        // Decrement the current object count
        pointCount--;
    }


    public void playPointSound(int i)
    {

        if (i == 1)
        {
            int randomIndex = Random.Range(0, Destroyed_Point_Sounds.Length);

            AudioSource.PlayClipAtPoint(Destroyed_Point_Sounds[randomIndex], CameraObject.transform.position, 0.5f);
        }
        else if (i == 2)
        {
            int randomIndex = Random.Range(0, Point_Sounds.Length);

            AudioSource.PlayClipAtPoint(Point_Sounds[randomIndex], CameraObject.transform.position, 0.5f);
        }
    }
}

