using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public float RandomSpawnTime() 
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
            StartCoroutine(spawnObstacels());
        }
    }

    IEnumerator spawnObstacels() {
        Reshuffle();

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

    // Function to randomize using the Fisher-Yates shuffle algorithm
    public void Reshuffle() {
        // Get the length of the array
        int n = spawnPoints.Length;

        // Create a new random number generator with a seed based on the current time in milliseconds
        System.Random rng = new System.Random(DateTime.Now.Millisecond);

        // Iterate through the array elements in reverse order
        while (n > 1)
        {
            // Decrement the index
            n--;

            // Generate a random index between 0 and the current index (inclusive)
            int k = rng.Next(n + 1);

            // Swap elements and ensure the new index is different from the current index
            while (k == n)
            {
                k = rng.Next(n + 1);
            }

            // Perform the swap of elements at indices k and n
            Transform value = spawnPoints[k];
            spawnPoints[k] = spawnPoints[n];
            spawnPoints[n] = value;
        }
    }
}

