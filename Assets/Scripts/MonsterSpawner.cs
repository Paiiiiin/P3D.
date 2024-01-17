using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;  // 怪物预制体
    public Transform[] spawnPoints;   // 刷新点数组
    public float spawnInterval = 5f;  // 刷新间隔（秒）
    private float timer;              // 计时器

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnMonster();
            timer = spawnInterval;
        }
    }

    void SpawnMonster()
    {
        if (spawnPoints.Length == 0) return;

        // 随机选择一个刷新点
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // 在选定的位置刷新怪物
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
