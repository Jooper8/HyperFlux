using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public float spawnInterval = 1f;
    public float spawnXPosition = 0f;
    public float verticalOffset = 0f;
    private float spawnTimer = 0f;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            Vector3 spawnPosition = new Vector3(spawnXPosition, playerTransform.position.y + verticalOffset, 0f);
            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }
}
