using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] Transform player_T;

    [SerializeField] float spawnTime = 3;
    float spawnTimer;
    [SerializeField] float spawnRange = 6;

    [SerializeField] List<GameObject> itemObjs;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTime)
        {
            spawnTimer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject obj = itemObjs[UnityEngine.Random.Range(0, itemObjs.Count)];

        // 반경 spawnRange 안쪽의 무작위 좌표
        Vector2 randomOffset = Random.insideUnitCircle * spawnRange;

        Vector3 spawnPosition = player_T.position + new Vector3(randomOffset.x, randomOffset.y, 0f);

        Instantiate(obj, spawnPosition, Quaternion.identity);
    }
}
