using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  public static GameManager     Instance;
  public        int             score;
  public        bool            gameOver;
  public        TextMeshProUGUI scoreText;

  private void Awake() { Instance = this; }

  public void GameOver() {
    gameOver = true;
    GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>().StopSpawning();
  }
  
  public void IncrementScore() {
    if (gameOver) return;
    score++;
    scoreText.text = score.ToString();
  }
}
