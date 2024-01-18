using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.UIElements;

[TestFixture]
public class SpawnerTests
{
    [Test]
    [TestCase(5, 10)]
    [TestCase(15, 100)]
    [TestCase(5, 6)]
    public void RandomSpawnTime_ReturnsRandomValueWithinRange(float a, float b)
    {
        // Arrange
        Spawner spawner = new GameObject().AddComponent<Spawner>();
        spawner.spawnTimeRange = new Vector2(a, b);

        // Act
        float randomSpawnTime = spawner.RandomSpawnTime();

        // Assert
        Assert.GreaterOrEqual(randomSpawnTime, a);
        Assert.LessOrEqual(randomSpawnTime, b);
    }

    [Test]
    [TestCase(4, 4, 4, 1, 1, 1, 2, 2, 2, 3, 3, 3)]
    public void Reshuffle_ShouldShuffleSpawnPoints(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
    {
        // Arrange
        Spawner spawner = new GameObject().AddComponent<Spawner>();

        Transform[] spawnPoints = new Transform[]
        {
            new GameObject().transform,
            new GameObject().transform,
            new GameObject().transform
        };

        spawnPoints[0].position = new Vector3(x1, y1, z1);
        spawnPoints[1].position = new Vector3(x2, y2, z2);
        spawnPoints[2].position = new Vector3(x3, y3, z3);

        spawner.spawnPoints = new Transform[] 
        {
            spawnPoints[0],
            spawnPoints[1],
            spawnPoints[2]
        };
        Transform[] originalSpawnPoints = spawner.spawnPoints.Clone() as Transform[];

        // Act
        spawner.Reshuffle();

        // Assert
        Assert.AreNotEqual(originalSpawnPoints, spawner.spawnPoints);
    }
}
