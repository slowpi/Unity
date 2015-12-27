using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject [] hazards;
    private GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float wavenWait;
    public Text scoreText;
    private int score;
    //public Text restartText;
    public Text gameOverText;
    private bool gameOver;
    //private bool restart;

    void Start()
    {
       score = 0;
       UpdateScore();
       StartCoroutine(SpawnWaves());
       scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
       //restartText = GameObject.Find("RestartText").GetComponent<Text>();
       gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
       gameOver = false;
       //restart = false;
    }
    /*void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }*/
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x), spawnValue.y, spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(wavenWait);
            if (gameOver)
            {
                //restartText.text = "Press 'R' for Restart";
                //restart = true;
                break;
            }
        }
    }
    public void AddScore(int newScoreText)
    {
        score += newScoreText;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
    public void RestartGame()
    {
                Application.LoadLevel(Application.loadedLevel);
    }
}
