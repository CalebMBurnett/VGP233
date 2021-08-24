using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] platforms;
    public GameObject[] enemies;

    private float platformSpawnDelay = 1.0f;
    public float platformRepeatRate;
    public float enemySpawnDelay;
    public float enemyRepeatRate;

    private Vector3 leftSpawnRange;
    private Vector3 rightSpawnRange;
    private float[] lpSpawnLevels = { 9.2f, 12.9f, 17.3f, 19.9f };
    private float[] rpSpawnLevels = { 8.6f, 12.3f, 16.7f, 19.3f };
    private float[] enemySpawnLevels = { 3.0f, 7.2f, 11.2f, 18.3f };

    private int levelIndex;
    private int pIndex;
    private int eIndex;
    
    void Start()
    {
        InvokeRepeating("RightSpawnPlatform", platformSpawnDelay, platformRepeatRate);
        InvokeRepeating("LeftSpawnPlatform", platformSpawnDelay, platformRepeatRate);
        InvokeRepeating("SpawnEnemy", enemySpawnDelay, enemyRepeatRate);
    }

    private void LeftSpawnPlatform()
    {
        levelIndex = Random.Range(0, 4);
        pIndex = Random.Range(0, platforms.Length);
        leftSpawnRange = new Vector3(-20f, lpSpawnLevels[levelIndex], -16.5f);
        Instantiate(platforms[pIndex], leftSpawnRange, platforms[pIndex].transform.rotation);
    }
    private void RightSpawnPlatform()
    {
        levelIndex = Random.Range(0, 4);
        pIndex = Random.Range(0, platforms.Length);
        rightSpawnRange = new Vector3(40f, rpSpawnLevels[levelIndex], -16.5f);
        Instantiate(platforms[pIndex], rightSpawnRange, platforms[pIndex].transform.rotation);
    }

    private void SpawnEnemy()
    {
        levelIndex = Random.Range(0, 4);
        int randomSide = Random.Range(0, 2);
        eIndex = Random.Range(0, enemies.Length);
        if (randomSide == 0)
        {
            leftSpawnRange = new Vector3(-20f, enemySpawnLevels[levelIndex], -16.5f);
            Instantiate(enemies[eIndex], leftSpawnRange, enemies[eIndex].transform.rotation);
        }
        else
        {
            rightSpawnRange = new Vector3(40f, enemySpawnLevels[levelIndex], -16.5f);
            Instantiate(enemies[eIndex], rightSpawnRange, enemies[eIndex].transform.rotation);
        }
    }
}
