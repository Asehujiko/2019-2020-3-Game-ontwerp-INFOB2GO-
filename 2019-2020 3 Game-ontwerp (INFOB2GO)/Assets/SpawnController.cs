using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private SpawnPoint[] spawnPoints;
    int numerEnemies;
    int playerStage;
    public int maxnumberEnemies;
    float spawntimer;

    void Start()
    {
        numerEnemies = 0;
        playerStage = 0;
        maxnumberEnemies = 2;
        spawnPoints = FindObjectsOfType<SpawnPoint>();
        EnemyController[] enemies = FindObjectsOfType<EnemyController>();
        numerEnemies = enemies.Length;
    }

    private void Update()
    {
        spawntimer -= Time.deltaTime;
        if (spawntimer <= 0)
        {
            spawntimer = 1;
            if (numerEnemies < maxnumberEnemies)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        for (int i = 0; i < maxnumberEnemies - numerEnemies; i++)
        {
            for (int j = 0; j < spawnPoints.Length; j++)
            {
                if (spawnPoints[j].AreaClear())
                {
                    spawnPoints[j].Spawn();
                    numerEnemies++;
                    i--;
                    break;
                }
            }
        }
    }

    public void Staged(int stage)
    {
        playerStage = stage;
        maxnumberEnemies = playerStage * 2;
    }

    public void Died()
    {
        numerEnemies--;
        Spawn();
    }
}