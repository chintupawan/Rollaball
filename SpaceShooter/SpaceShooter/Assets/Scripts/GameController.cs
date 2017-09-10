using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class GameController : MonoBehaviour
{

    public GameObject Hazard;
    public Vector3 SpawnValues;
    public int HazardCount;
    public float SpawnWait, WaveWait, StartWait;
    public GUIText ScoreText, RestartText, GameOverText;
    
    public int CurrentScore;
    public Button button;
    private bool gameOver, restart;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        RestartText.text = GameOverText.text = "";
        CurrentScore = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.anyKey)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(StartWait);
        while (true)
        {
            for (int i = 0; i < HazardCount; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(-SpawnValues.x, SpawnValues.x), 0.0f, SpawnValues.z);
                Quaternion spawnRot = Quaternion.identity;
                Instantiate(Hazard, spawnPos, spawnRot);
                yield return new WaitForSeconds(SpawnWait);
            }

            yield return new WaitForSeconds(WaveWait);
            if (gameOver)
            {
                RestartText.text = "Press R for Restart";
                restart = true;
                button.visible = true;
                break;
            }
        }
        
    }

    public void AddScore(int newScore)
    {
        CurrentScore += newScore;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverText.text = "Game Over";
    }
    void UpdateScore()
    {
        ScoreText.text = "Score: " + CurrentScore;
    }
}
