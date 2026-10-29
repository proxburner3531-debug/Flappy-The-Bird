using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipesPrefab;

    [SerializeField] private float maxHeightOffset = 10f; 
    private float spawnRate = 1f;
    private float timeSinceLastSpawn = 0f;
    private void Start()
    {
        SpawnPipes();
    }
    private void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= spawnRate)
        {
            SpawnPipes();
            timeSinceLastSpawn = 0f;
        }

        
    }

    private void SpawnPipes()
    {
        float maxPointPipes = transform.position.y + maxHeightOffset;
        float minPointPipes = transform.position.y - maxHeightOffset;

        Instantiate(pipesPrefab, new Vector2(transform.position.x, Random.Range(minPointPipes, maxPointPipes)), Quaternion.identity);
    }
}
