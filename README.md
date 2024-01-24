# Care Game Modul 450

## Einführung

Dieses Projekt umfasst ein kleines 3D-Spiel, bei dem der Spieler ein Auto steuert und Hindernissen wie Wänden, Kakteen und Palmen ausweichen muss. Das Spiel wird im Verlauf zunehmend schwieriger. Der Spieler verliert, wenn das Auto mit einem Objekt kollidiert. Ziel dieses Moduls ist es Test für das Spiel zu Programmieren.

**Steuerung:**

-   Linke Pfeiltaste: Steuert Auto nach links.
-   Rechte Pfeiltaste: Steuert Auto nach rechts.

![Screenshot 2022-01-20 142751.png](/Assets/IMPORTET/23.png)

## Tests ausführen

Im folgenden Abschnitt wird erklärt, wie die Test für das Unity-Spiel ausgeführt werden können.

1. Installieren Sie den Unity Editor.
2. Öffnene Sie das Projekt in Unity.
3. Gehen Sie unter Windows->General->Test Runner->Run All
   ![Anleitung für Test Runner](/Images/TestRunner.png) Danach werden alle Test ausgeführt. Zudem öffnet sich ein Ordner, wenn man auf index.html öffnet kann man die Code Covrage der Test ansehen.

## Planung

-   **26.10.2023 - 2.11.2023:** Testkonzept für Projekt schreiben.
-   **09.11.2023 - 16.11.2023:** Mit Unit Test in Unity auseinandersetzen.
-   **28.12.2023 - 11.01.2024:** Eigene Test für Spiel schreiben.
-   **18.01.2024 - 18.01.2024:** Präsentation vorbereiten und Dokumentation schreiben.

## Projekt Struktur

Die folgenden Klassen exisitern in meinem Projekt.

```csharp
class Score: MonoBehaviour {
  - int score
  - int highscore
  - TextMeshProUGUI scoreText
  - TextMeshProUGUI menuScoreText
  - TextMeshProUGUI menuHighscoreText

  + Start()
  + Update()
  + ResetScore()
  + AddScore()
  + SaveScore()
}

class PlayerMove: MonoBehaviour {
  - Rigidbody rb
  - float speed
  - GameObject gameOverPanel

  + Start()
  + Update()
  + OnTriggerEnter(Collider other)
}

class Spawner: MonoBehaviour {
  - GameObject[] obstacles
  - Transform[] spawnPoints
  - Vector2 spawnTimeRange
  - float spwanTime
  - float timer
  - Vector2 defficultyRange
  - Vector2 sizeRange
  - Vector2 delayRange

  + Start()
  + RandomSpawnTime()
  + Update()
  + spawnObstacels()
  + Reshuffle()
}

class Obstacle: MonoBehaviour {
  - Rigidbody rb
  - float speed

  + Start()
  + Update()
}
```

Zudem sind zwei neue Test Klassen hinzugekomment, sie befinden sich unter '\Assets\Tests\EditoMode'

```csharp
[TestFixture]
public class ScoreTests
{
    - ResetScore_ResetsScoreVariableToZero()
    - ResetScore_ResetsScorePlayerPrefsToZero()
    - AddScore_IncreasesScoreByOne(int a, int expected)
    - SaveScore_UpdatesHighscoreVariableIfCurrentScoreIsHigher(int a, int b, int expected)
    - SaveScore_DoesNotUpdateHighscoreIfCurrentScoreIsLower(int a, int b, int expected)
    - SaveScore_HighscorePlayerPrefsGetsUpdated(int a, int expected)
    - SaveScore_SavesCurrentScoreInPlayerPrefs(int a, int expected)
}

[TestFixture]
public class SpawnerTests
{
    - RandomSpawnTime_ReturnsRandomValueWithinRange(float a, float b)
    - Reshuffle_ShouldShuffleSpawnPoints(float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
}
```

## Test Items

Getestet werden folgenden Funktionen:

```csharp
//Score.cs
+ ResetScore()
+ AddScore()
+ SaveScore()

//Spawner.cs
+ RandomSpawnTime()
+ Reshuffle()
```

## Features not to be tested

Folgende Dinge werden nicht getestet. Die Funktion Start und Update sind standart Funktionen von Unity. Start wird immer bei der Instanzierung eines Objektes ausgeführt und Update alle 60 Frames weshalb es keinen Sinn macht diese zu testen. OnTriggerEnter(Collider other) wird nicht getest da diese Methode inheralb von Unity Kolisionen überprüft, was nicht mit Unit Test getested werden kann. spawnObstacels kann nicht getested werden, da es ein Coroutine ist.

```csharp
//Score.cs
+ Start()
+ Update()

//PlayerMove.cs
+ Start()
+ Update()
+ OnTriggerEnter(Collider other)

//Spawner.cs
+ Start()
+ Update()
+ spawnObstacels()

//Obstacle.cs
+ Start()
+ Update()
```

## Approach

In diesem Projekt werden Komponententest und Unit Tests durchgeführt. TDD wird nicht eingesetzt, da das Projekt schon fertig programmiert ist.

## Item pass / fail criteria

### Score.cs

| Function     | Pass Criteria                                                            | Fail Criteria                                                      |
| ------------ | ------------------------------------------------------------------------ | ------------------------------------------------------------------ |
| ResetScore() | Score variable set to 0.                                                 | Score variable not set to 0.                                       |
|              | PlayerPrefs "score" updated with the new score value.                    | PlayerPrefs "score" not updated.                                   |
| AddScore()   | Score variable incremented by 1.                                         | Score variable not updated by the increment of 1.                  |
| SaveScore()  | If current score > highscore, update highscore variable.                 | Current score > highscore, highscore is not set to value of score. |
|              | If highscore is > score, highscore should not update highscore variable. | Highscore > score, updates highscore to score value                |
|              | PlayerPrefs "highscore" updated with the new highscore value.            | PlayerPrefs "highscore" not updated.                               |
|              | PlayerPrefs "score" updated with the current score value.                | PlayerPrefs "score" not updated.                                   |

### Spawn.cs

| Function          | Pass Criteria                                               | Fail Criteria                                              |
| ----------------- | ----------------------------------------------------------- | ---------------------------------------------------------- |
| RandomSpawnTime() | Returns a random value within the specified spawnTimeRange. | Does not return a random value within the specified range. |
| Reshuffle()       | Shuffles the elements in the spawnPoints array.             | Does not shuffle the elements in the spawnPoints array.    |

## Test Deliverables

Es wurden folgende Test-Artefakte verwendet:

-   Testkonzept
-   Visual Studio Community
-   Unity Test Framework (UTF)

## Environmental Needs

-   Unity 2020.3.24f1
-   Visual Studio Community
-   Unity Test Framework (UTF)

## Fazit

Ich habe es als sehr spannend empfunden, Tests speziell für ein Unity-Projekt zu schreiben, da der Prozess meiner Meinung nach etwas anders ist als beispielsweise beim Schreiben von Tests für ein Java-Projekt. Eine große Herausforderung bestand darin, dass es nicht sehr wenig Dokumentationen und Ressourcen zum Thema Testing in Unity gibt. Am Ende ist es mir jedoch trotzdem gelungen, einige Tests zu schreiben und diese erfolgreich auszuführen. Zudem konnte ich auch die Code Covrage hinzufügen.
