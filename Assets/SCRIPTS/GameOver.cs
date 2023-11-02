using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject MenuPanel;
    public Spawner spawnerScript;

    void Start() {
        spawnerScript.enabled = false;
        Time.timeScale = 0;
    }

    public void StartGame() 
    {
        FindObjectOfType<Score>().ResetScore();
        MenuPanel.SetActive(false);
        spawnerScript.enabled = true;
        Time.timeScale = 1;
    }

    public void GameEnd () {
        FindObjectOfType<Score>().SaveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
