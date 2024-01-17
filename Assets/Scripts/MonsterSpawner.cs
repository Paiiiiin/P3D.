using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;  // ����Ԥ����
    public Transform[] spawnPoints;   // ˢ�µ�����
    public float spawnInterval = 5f;  // ˢ�¼�����룩
    private float timer;              // ��ʱ��

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

        // ���ѡ��һ��ˢ�µ�
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ��ѡ����λ��ˢ�¹���
        Instantiate(monsterPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
