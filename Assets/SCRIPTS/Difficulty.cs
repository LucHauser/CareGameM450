using System.Collections;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public Vector2 increaseRange;
    public float evry;
    public float timeScale;

    void Start()
    {
        StartCoroutine(IncreaseSpeed());
    }

    IEnumerator IncreaseSpeed() {
        yield return new WaitForSeconds(evry);
        Time.timeScale += Random.Range(increaseRange.x, increaseRange.y);
        StartCoroutine(IncreaseSpeed());
        timeScale = Time.timeScale;
    }
}
