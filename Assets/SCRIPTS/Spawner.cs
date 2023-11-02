using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public Transform[] spawnPoints;

    public Vector2 spawnTimeRange;
    public float spwanTime;
    public float timer;

    public Vector2 defficultyRange;
    public Vector2 sizeRange;
    public Vector2 delayRange;
 
    void Start()
    {
        spwanTime = RandomSpawnTime();
    }

    float RandomSpawnTime() 
    {
        return Random.Range(spawnTimeRange.x, spawnTimeRange.y);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spwanTime) 
        {
            timer = 0;
            spwanTime = RandomSpawnTime();
            StartCoroutine(SpawnObstacels());
        }
    }

    IEnumerator SpawnObstacels() {
        reshuffle();

        float difficulty = Random.Range(defficultyRange.x, defficultyRange.y);
        for (int i = 0; i < difficulty; i++) {
            GameObject obstacle = Instantiate(obstacles[Random.Range(0, obstacles.Length)], spawnPoints[i].position, Quaternion.identity);
            float size = Random.Range(sizeRange.x, sizeRange.y);
            obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x * size, obstacle.transform.localScale.y * size, obstacle.transform.localScale.z * size);
            obstacle.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            yield return new WaitForSeconds(Random.Range(delayRange.x, delayRange.y));
        }

        FindObjectOfType<Score>().AddScore();
    }

    void reshuffle() {
        for (int t = 0; t < spawnPoints.Length; t++) {
            Transform tmp = spawnPoints[t];
            int r = Random.Range(t, spawnPoints.Length);
            spawnPoints[t] = spawnPoints[r];
            spawnPoints[r] = tmp;
        }
    }
}

