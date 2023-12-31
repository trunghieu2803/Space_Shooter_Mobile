﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private Camera mainCam;
    private float maxLeft;
    private float maxRight;
    private float yPos;

    [Header("Enemy Prefabs")]
    [SerializeField] private GameObject[] enemy;

    private float enemyTimer;
    [Space(15)]
    [SerializeField] private float enemySpawnTime;
    void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundaries());
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        enemyTimer += Time.deltaTime;
        if(enemyTimer >= enemySpawnTime )
        {
            int randomPick = Random.Range(0, enemy.Length);
            Instantiate(enemy[randomPick], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);
            enemyTimer = 0;
        }
    }
    private IEnumerator SetBoundaries()
    {
        // Đợi 0.4 giây
        yield return new WaitForSeconds(0.4f);

        // Tính toán và gán giá trị maxLeft, maxRight, maxDown, maxUp
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
    }
}
