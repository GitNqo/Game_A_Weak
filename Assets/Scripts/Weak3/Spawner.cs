using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public Vector3 spawnArea = new Vector3(5f, 3f, 5f);

    private float timer;
    private float spawnInterval;

    void Start()
    {
        spawnInterval = DifficultyManager.instance.GetSpawnInterval();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    void SpawnObject()
    {
        Vector3 randomPos = new Vector3(
            Random.Range(-spawnArea.x, spawnArea.x),
            Random.Range(-spawnArea.y, spawnArea.y),
            Random.Range(-spawnArea.z, spawnArea.z)
        );

        GameObject obj = Instantiate(prefab, randomPos, Quaternion.identity);

        // õ–½‚ğİ’èi©“®Á–Åj
        float lifeTime = DifficultyManager.instance.GetObjectLifetime();
        Destroy(obj, lifeTime);
    }
}
