using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

  public void GameScene(string gameScene) {
    SceneManager.LoadScene(gameScene);
  }
  
  public void Exit() {
    Debug.Log("Has salido del juego");
    Application.Quit();
  }
}
