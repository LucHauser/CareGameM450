using NUnit.Framework;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TestTools;
using UnityEngine.UI;

[TestFixture]
public class ScoreTests
{
    [Test]
    public void ResetScore_ResetsScoreVariableToZero()
    {
        // Arrange
        var scoreObject = new GameObject().AddComponent<Score>();

        // Set Score to other value then 0.
        scoreObject.score = 20;

        // Act
        scoreObject.ResetScore();

        // Assert
        Assert.AreEqual(0, scoreObject.score);
    }

    [Test]
    public void ResetScore_ResetsScorePlayerPrefsToZero()
    {
        // Arrange
        var scoreObject = new GameObject().AddComponent<Score>();

        // Set PlayerPrefs Score to other value then 0.
        PlayerPrefs.SetInt("score", 20);

        // Act
        scoreObject.ResetScore();

        // Assert
        Assert.AreEqual(0, PlayerPrefs.GetInt("score"));
    }

    [Test]
    [TestCase(1, 2)]
    [TestCase(10, 11)]
    [TestCase(22, 23)]
    [TestCase(0, 1)]
    public void AddScore_IncreasesScoreByOne(int a, int expected)
    {
        // Arrange
        var scoreObject = new GameObject().AddComponent<Score>();
        scoreObject.score = a;

        // Act
        scoreObject.AddScore();

        // Assert
        Assert.AreEqual(expected, scoreObject.score);
    }

    [Test]
    [TestCase(10, 5, 10)]
    [TestCase(5, 4, 5)]
    [TestCase(100, 89, 100)]
    public void SaveScore_UpdatesHighscoreVariableIfCurrentScoreIsHigher(int a, int b, int expected)
    {
        // Arrange
        var scoreObject = new GameObject().AddComponent<Score>();
        scoreObject.score = a;
        scoreObject.highscore = b;

        // Act
        scoreObject.SaveScore();

        // Assert
        Assert.AreEqual(expected, scoreObject.highscore);
    }

    [Test]
    [TestCase(5, 9, 9)]
    [TestCase(20, 60, 60)]
    [TestCase(0, 1, 1)]
    public void SaveScore_DoesNotUpdateHighscoreIfCurrentScoreIsLower(int a, int b, int expected)
    {
        // Arrange
        var scoreObject = new GameObject().AddComponent<Score>();
        scoreObject.score = a;
        scoreObject.highscore = b;

        // Act
        scoreObject.SaveScore();

        // Assert
        Assert.AreEqual(expected, scoreObject.highscore);
    }

    [Test]
    [TestCase(5, 5)]
    [TestCase(33, 33)]
    [TestCase(100, 100)]
    public void SaveScore_HighscorePlayerPrefsGetsUpdated(int a, int expected)
    {
        // Arrange
        PlayerPrefs.DeleteAll();
        var scoreObject = new GameObject().AddComponent<Score>();
        scoreObject.score = a;

        // Act
        scoreObject.SaveScore();

        // Assert
        Assert.AreEqual(expected, PlayerPrefs.GetInt("highscore"));
    }

    [Test]
    [TestCase(5, 5)]
    [TestCase(33, 33)]
    [TestCase(100, 100)]
    public void SaveScore_SavesCurrentScoreInPlayerPrefs(int a, int expected)
    {
        // Arrange
        var scoreObject = new GameObject().AddComponent<Score>();
        scoreObject.score = a;

        // Act
        scoreObject.SaveScore();

        // Assert
        Assert.AreEqual(expected, PlayerPrefs.GetInt("score"));
    }
}
