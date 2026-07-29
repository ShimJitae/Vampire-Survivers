using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] float spawnTime = 3;
    float spawnTimer;

    [SerializeField] float spawnRange = 6;

    public void AddTime(float timeDelta)
    {
        spawnTimer += timeDelta;
        if (spawnTimer > spawnTime)
        {
            spawnTimer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {

    }
}
