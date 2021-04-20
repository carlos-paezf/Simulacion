using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour{
  
  public Life life;
  public bool vida0 = false;

  [SerializeField]
  private Animator _loseAnimation;

  public ScorePlayer valueScorePrefab;
    
  void Start() {
    life                   = GetComponent<Life>();
    valueScorePrefab.value = 0;
  }

  void Update() {
    CheckLife();
  }

  private void CheckLife() {
    if (vida0) return;
    if (life.value <= 0) {
      AudioListener.volume = 0;
      _loseAnimation.SetTrigger("Show");
      vida0 = true;
      Invoke("RestartGame", 2f);
    }
  }

  /*Para arreglar el problema de iluminación, luego de revivir, ingresar a
   window -> Rendering -> Lighting Settings -> Desmarcar Auto Generate ->
   Generate Lighting
   */
  private void RestartGame() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    AudioListener.volume   = 1;
    valueScorePrefab.value = 0;
  }

  private void OnTriggerStay(Collider other) {
    if (other.gameObject.tag == "Enemy") {
      gameObject.GetComponent<AudioSource>().volume = 0.5f;
    }
  }

  private void OnTriggerExit(Collider other) {
    if (other.gameObject.tag == "Enemy") {
      gameObject.GetComponent<AudioSource>().volume = 1f;
    }
  }
}
