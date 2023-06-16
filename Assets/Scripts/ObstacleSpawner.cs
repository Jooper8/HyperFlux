using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs
    public float spawnInterval = 1f; // Time interval between each obstacle spawn
    public float spawnXPosition = 0f; // Fixed horizontal position for obstacle spawn
    public float verticalOffset = 0f; // Offset to the player's vertical position

    private float spawnTimer = 0f;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a new obstacle
        if (spawnTimer >= spawnInterval)
        {
            // Reset the spawn timer
            spawnTimer = 0f;

            // Randomly select an obstacle prefab from the array
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

            // Spawn the obstacle with an offset to the player's vertical position
            Vector3 spawnPosition = new Vector3(spawnXPosition, playerTransform.position.y + verticalOffset, 0f);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
