using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyGeneratorScript : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;
    public GameObject CameraObject;

    [SerializeField]
    private AudioClip[] Destroyed_Enemy_Sounds;

    public float spawnRate = 1f;
    public float spawnRadius = 2f;
    private float nextSpawnTime = 1f;
    float leftEdge;
    float rightEdge;
    float topEdge;
    float bottomEdge;
    void Start()
    {
        CameraObject = GameObject.Find("Main Camera");

        nextSpawnTime = Time.time + 1;
        player = GameObject.Find("Player");
        leftEdge = -(Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height));
        rightEdge = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        topEdge = Camera.main.orthographicSize;
        bottomEdge = -Camera.main.orthographicSize;

    }

    void Update()
    {


        leftEdge = -(Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height));
        rightEdge = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);
        topEdge = Camera.main.orthographicSize;
        bottomEdge = -Camera.main.orthographicSize;

        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + 1 / spawnRate;

            if (GameManagerScript.level == 1)
            {
                //Code for Enemy 1
                // Spawn the enemy randomly across one of the edges of the screen
                Vector3 spawnPosition = Vector3.zero;
                int randomEdge = Random.Range(1, 5);
                switch (randomEdge)
                {
                    case 1: // Top Edge
                        spawnPosition = new Vector3(Random.Range(leftEdge + 1, rightEdge - 1), topEdge, 0);
                        break;
                    case 2: // Right Edge
                        spawnPosition = new Vector3(rightEdge, Random.Range(bottomEdge + 1, topEdge - 1), 0);
                        break;
                    case 3: // Bottom Edge
                        spawnPosition = new Vector3(Random.Range(leftEdge + 1, rightEdge - 1), bottomEdge, 0);
                        break;
                    case 4: // Left Edge
                        spawnPosition = new Vector3(leftEdge, Random.Range(bottomEdge + 1, topEdge - 1), 0);
                        break;
                }
                GameObject e = Instantiate(enemy1Prefab, spawnPosition, Quaternion.identity);
                EnemyScript enemyController = e.GetComponent<EnemyScript>();

                Vector2 direction = new Vector2(0, 0);
                switch (randomEdge)
                {
                    case 1: // Top Edge
                        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, -0.7071f)).normalized;
                        break;
                    case 2: // Right Edge
                        direction = new Vector2(Random.Range(-1f, -0.7071f), Random.Range(-1f, 1f)).normalized;
                        break;
                    case 3: // Bottom Edge
                        direction = new Vector2(Random.Range(-1f, 1f), Random.Range(0.7071f, 1f)).normalized;
                        break;
                    case 4: // Left Edge
                        direction = new Vector2(Random.Range(0.7071f, 1f), Random.Range(-1f, 1f)).normalized;
                        break;
                }
                // Get the current value of the "direction" variable
                enemyController.direction = direction;
            }
            else if (GameManagerScript.level == 2)
            {
                //Code for Enemy 2
                // Spawn the enemy randomly across one of the edges of the screen
                Vector3 spawnPosition = Vector3.zero;
                int randomEdge = Random.Range(1, 5);
                switch (randomEdge)
                {
                    case 1: // Top Edge
                        spawnPosition = new Vector3(Random.Range(leftEdge + 1, rightEdge - 1), topEdge, 0);
                        break;
                    case 2: // Right Edge
                        spawnPosition = new Vector3(rightEdge, Random.Range(bottomEdge + 1, topEdge - 1), 0);
                        break;
                    case 3: // Bottom Edge
                        spawnPosition = new Vector3(Random.Range(leftEdge + 1, rightEdge - 1), bottomEdge, 0);
                        break;
                    case 4: // Left Edge
                        spawnPosition = new Vector3(leftEdge, Random.Range(bottomEdge + 1, topEdge - 1), 0);
                        break;
                }
                GameObject e = Instantiate(enemy2Prefab, spawnPosition, Quaternion.identity);
                EnemyScript enemyController = e.GetComponent<EnemyScript>();

                Vector2 direction = (player.transform.position - spawnPosition).normalized;

                // Get the current value of the "direction" variable
                enemyController.direction = direction;
            }
            else if (GameManagerScript.level == 3)
            {
                //Code for Enemy 2
                // Spawn the enemy randomly across one of the edges of the screen
                Vector3 spawnPosition = Vector3.zero;
                int randomEdge = Random.Range(1, 5);
                switch (randomEdge)
                {
                    case 1: // Top Edge
                        spawnPosition = new Vector3(Random.Range(leftEdge + 1, rightEdge - 1), topEdge, 0);
                        break;
                    case 2: // Right Edge
                        spawnPosition = new Vector3(rightEdge, Random.Range(bottomEdge + 1, topEdge - 1), 0);
                        break;
                    case 3: // Bottom Edge
                        spawnPosition = new Vector3(Random.Range(leftEdge + 1, rightEdge - 1), bottomEdge, 0);
                        break;
                    case 4: // Left Edge
                        spawnPosition = new Vector3(leftEdge, Random.Range(bottomEdge + 1, topEdge - 1), 0);
                        break;
                }
                GameObject e = Instantiate(enemy3Prefab, spawnPosition, Quaternion.identity);
                Enemy3Script enemyController = e.GetComponent<Enemy3Script>();

                Vector2 direction = (player.transform.position - spawnPosition).normalized;
                // Get the current value of the "direction" variable
                enemyController.direction = direction;
            }

            }
    }

    public void playEnemySound(int i)
    {

        if (i == 1)
        {
            int randomIndex = Random.Range(0, Destroyed_Enemy_Sounds.Length);

            AudioSource.PlayClipAtPoint(Destroyed_Enemy_Sounds[randomIndex], CameraObject.transform.position, 0.5f);
        }
    }
}