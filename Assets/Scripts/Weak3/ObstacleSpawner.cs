using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float moveSpeed = 5f;
    private float timer = 0f;

    [System.Obsolete]
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            GameObject obs = Instantiate(obstaclePrefab, new Vector3(8f, -2.5f, 0), Quaternion.identity);
            obs.GetComponent<Rigidbody2D>().velocity = Vector2.left * moveSpeed;
            Destroy(obs, 6f); // 6ïbå„Ç…é©ìÆçÌèú
            timer = 0f;
        }
    }
}
