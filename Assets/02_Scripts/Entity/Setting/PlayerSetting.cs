using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    [SerializeField] Status status;
    [SerializeField] List<Item> canGetItems;
    private float exp;
    private int level = 1;


    public Entity PlayerEntity { get; set; }
    float currPlayerHP;




    void Awake()
    {
        PlayerEntity = GetComponent<Entity>();
        PlayerEntity.HP = status.HP;
        GetComponent<Module_Move>().MoveSpeed = status.Speed;
    }

    void Update()
    {
        if (PlayerEntity.IsDied)
        {
            if (!GameManager.Instance.IsGameOver)
                GameManager.Instance.OnGameOver.Invoke();
            return;
        }

        if (currPlayerHP != PlayerEntity.HP)
        {
            currPlayerHP = PlayerEntity.HP;
            UIManager.Instance.SetSliderValue(SliderEnum.HP, currPlayerHP);
        }
    }

    void Start()
    {
        currPlayerHP = PlayerEntity.HP;
        UIManager.Instance.SetSliderValue(SliderEnum.HP, currPlayerHP);
        UIManager.Instance.LevelText.text = $"Level : {level}";

        StartCoroutine(FindNearestEnemy());
    }

    // 아이템 만들기
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            if (collision.gameObject.GetComponent<Item>() is Item item)
                item.Use(this);
        }
    }

    public void UpdateEXP(float value)
    {
        exp += value;

        if (exp >= 100)
        {
            level++;
            exp -= 100;
            UIManager.Instance.LevelText.text = $"Level : {level}";


        }

        UIManager.Instance.SetSliderValue(SliderEnum.EXP, exp);
    }


    // 스킬북
    [SerializeField] float detectRange = 8;
    public Transform NearestEnemy { get; set; }
    public IEnumerator FindNearestEnemy()
    {
        yield return new WaitForSeconds(1.5f);

        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(transform.position, detectRange);

        NearestEnemy = null;
        float nearestDistanceSqr = Mathf.Infinity;

        foreach (Collider2D detectedObject in detectedObjects)
        {
            if (!detectedObject.CompareTag("Monster"))
                continue;

            Vector2 direction = detectedObject.transform.position - transform.position;

            float distanceSqr = direction.sqrMagnitude;

            if (distanceSqr < nearestDistanceSqr)
            {
                nearestDistanceSqr = distanceSqr;
                NearestEnemy = detectedObject.transform;
            }
        }

        if (NearestEnemy != null)
        {
            Debug.Log($"가장 가까운 몬스터: {NearestEnemy.name}");
        }
    }
}
