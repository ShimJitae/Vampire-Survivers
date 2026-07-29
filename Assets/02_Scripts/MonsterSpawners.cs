using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(ObjectPool))]
public class MonsterSpawners : MonoBehaviour
{
    #region 스폰 관련 변수들
    [SerializeField] ObjectPool monster_Pool;
    [SerializeField] List<MonsterData> difficulty;
    [SerializeField] float spawnTime_Min, spawnTime_Max;
    [SerializeField] int spawnNum_Min, spawnNum_Max;
    float curr_SpawnTime, spawnTimer;
    List<Transform> spawnerPositions;
    # endregion

    void Awake()
    {
        spawnerPositions = new(8);
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnerPositions.Add(transform.GetChild(i));
        }
        curr_SpawnTime = Random.Range(spawnTime_Min, spawnTime_Max);
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > curr_SpawnTime)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int spawnNum = Random.Range(spawnNum_Min, spawnNum_Max);

        // spawnNum 만큼 몬스터 생성
        for (int i = 0; i < spawnNum; i++)
        {
            Transform spawnPos = spawnerPositions[Random.Range(0, spawnerPositions.Count)];

            GameObject monster = monster_Pool.Get();
            monster.transform.position = spawnPos.position;

            if (monster.GetComponent<Module_Move>() is Module_Move mmm
            && mmm.SMD == null)
            {
                SMD_Monster smdm = mmm.AddComponent<SMD_Monster>();
                mmm.SMD = smdm;
            }

            MonsterData md = difficulty[Random.Range(0, difficulty.Count)];
            monster.GetComponent<Entity>().HP = md.HP;
            monster.GetComponent<Module_Move>().MoveSpeed = md.Speed;
        }

        // 스폰 후에는 스폰타이머 재설정
        spawnTimer = 0;
        curr_SpawnTime = Random.Range(spawnTime_Min, spawnTime_Max);
    }
}
