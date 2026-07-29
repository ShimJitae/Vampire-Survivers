using UnityEngine;
using System.Collections.Generic;


// 오브젝트 풀링을 사용하는 이유
// 가비지 콜렉터의 Instantiate / Destroy 호출 횟수를 줄이기 위해
public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pooledPrefab;
    [SerializeField] private int poolSize;

    // ObjectPool을 만들 때, 어떤 자료구조를 만들었는지는 정해져 있지 않다.
    // 다만 사용한 자료구조를 설명할 수는 있는 이유는 있어야 한다.

    private Queue<GameObject> pool = new Queue<GameObject>();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            // 오브젝트 풀링할 프리팹을 풀 크기만큼 만들어준다.
            GameObject obj = Instantiate(pooledPrefab, transform);
            // 생성했으면 비활성화한다.
            obj.SetActive(false);
            // 풀에 넣어준다.
            pool.Enqueue(obj);
        }
    }

    // 풀에서 가져다 씀
    public GameObject Get()
    {
        GameObject obj;
        // 풀에서 오브젝트를 가져와서 반환하는 역할.
        if (pool.Count > 0)
        {
            // 풀에서 가져온 오브젝트를
            obj = pool.Dequeue();
            // 활성화하고
            obj.SetActive(true);
        }
        else
        {
            // 만약 풀에 있는 오브젝트가 부족한 상황이라면 어떻게 할 것인가.
            // 꺼내오지 않고 새로 만듦
            obj = Instantiate(pooledPrefab);
            // 혹은 새로운 큐를 다시 만들 수도 있음.
        }

        obj.transform.SetParent(null);

        // 반환
        return obj;
    }

    // 풀에다 가져다 두는 것

    public void Return(GameObject obj)
    {
        obj.transform.SetParent(transform);
        // 비활성화하고
        obj.SetActive(false);
        // 풀에 넣어줌.
        pool.Enqueue(obj);
    }
}
