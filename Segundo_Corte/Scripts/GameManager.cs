using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public static GameManager     Instance;
  private       int             _score;
  public        bool            gameOver;
  public        TextMeshProUGUI scoreText;

  private void Awake() {
    Instance = this;
  }

  public void GameOver() {
    gameOver = true;
    GameObject.Find("ObstacleSpawner").GetComponent<ObstacleSpawner>().StopSpawning();
  }
  
  public void IncrementScore() {
    if (!gameOver) {
      _score++;
      scoreText.text = _score.ToString();
    }
  }
}
