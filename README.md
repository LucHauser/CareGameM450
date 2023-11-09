# Care Game Modul 450

## Intoduction

Dieses Projekt umfasst ein kleines 3D-Spiel, der Spiel steuert ein Auto und muss Hinderenisen, wie Wände, Kaktehen und Palemn aus weichen. Das Spiel wird mit der Zeit immer schwieriger. Der Spieler hat verlohren, wenn er in etwas hinein fährt.

**Steuerung:**

-   Linke Pfeiltaste: Steuert Auto nach links.
-   Rechte Pfeiltaste: Steuert Auto nach rechts.

![Screenshot 2022-01-20 142751.png](/Assets/IMPORTET/23.png)

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
  + SpawnObstacels()
  + reshuffle()
}

class Obstacle: MonoBehaviour {
  - Rigidbody rb
  - float speed

  + Start()
  + Update()
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
+ Update()
+ SpawnObstacels()
+ reshuffle()
```

## Features not to be tested

Folgende Dinge werden nicht getestet. Die Funktion Start und Update sind standart Funktionen Unity. Start wird immer bei der Instanzierung eines Objektes ausgeführt und Update alle 60 Frames weshalb es keinen Sinn macht diese zu testen. OnTriggerEnter(Collider other) wird nicht getest da diese Methode inheralb von Unity Kolisionen testet, was nicht mit Unit Test umgesetzwerden kann.

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

//Obstacle.cs
+ Start()
+ Update()
```

## Approach

In diesem Projekt werden Komponententest und Unit Tests durchgeführt. TDD wird nicht eingesetzt, da das Projekt schon fertig programmiert ist.

## Item pass / fail criteria

### Score.cs

| Function     | Pass Criteria                                                   | Fail Criteria                                       |
| ------------ | --------------------------------------------------------------- | --------------------------------------------------- |
| ResetScore() | - Score variable set to 0.                                      | - Score variable not set to 0.                      |
|              | - PlayerPrefs "score" updated with the new score value.         | - PlayerPrefs "score" not updated.                  |
| AddScore()   | - Score variable incremented by 1.                              | - Score variable not updated by the increment of 1. |
| SaveScore()  | - If current score > highscore, update highscore variable.      | - Current score <= highscore, no update made.       |
|              | - PlayerPrefs "highscore" updated with the new highscore value. | - PlayerPrefs "highscore" not updated.              |
|              | - PlayerPrefs "score" updated with the current score value.     | - PlayerPrefs "score" not updated.                  |

### Spawn.cs

| Function          | Pass Criteria                                                              | Fail Criteria                                                       |
| ----------------- | -------------------------------------------------------------------------- | ------------------------------------------------------------------- |
| RandomSpawnTime() | - Returns a random value within the specified `spawnTimeRange`.            | - Does not return a random value within the specified range.        |
| Update()          | - Increments the `timer` variable by the time passed since the last frame. | - Does not increment the `timer` variable.                          |
| SpawnObstacles()  | - Calls the `reshuffle()` function.                                        | - Does not call the `reshuffle()` function.                         |
|                   | - Spawns obstacles based on the specified difficulty range.                | - Does not spawn obstacles based on the specified difficulty range. |
|                   | - Adjusts the size and rotation of spawned obstacles accordingly.          | - Does not adjust the size and rotation of spawned obstacles.       |
|                   | - Delays between spawning obstacles.                                       | - Does not have delays between spawning obstacles.                  |
| reshuffle()       | - Shuffles the elements in the `spawnPoints` array.                        | - Does not shuffle the elements in the `spawnPoints` array.         |

## Test Deliverables

Es wurden folgende Test-Artefakte verwendet:

-   Dokuemntation
-   Testkonzept
-   Visual Studio Community
-   Unity Test Framework (UTF)

## Testing Tasks

Es werden nur Unit-Test eingesetzt.

## Environmental Needs

-   Unity 2020.3.24f1
-   Visual Studio Community
-   Unity Test Framework (UTF)
