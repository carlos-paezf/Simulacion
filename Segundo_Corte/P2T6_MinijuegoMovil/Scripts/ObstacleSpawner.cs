using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour {
    
  public  GameObject obstacle;
  public  float      spawnRate;
  public  float      maxPositionX;

  private void Start() {
    StartCoroutine(Spawn()); 
  }
  
  // private void Update() { if (Input.GetKeyDown(KeyCode.A)) Spawn(); }

  private IEnumerator Spawn() {
    var randomX       = Random.Range(-maxPositionX, maxPositionX);
    var spawnPosition = new Vector2(randomX, transform.position.y);
    Instantiate(obstacle, spawnPosition, Quaternion.identity);
    spawnRate -= 0.05f;
    yield return new WaitForSeconds(spawnRate);
    if (spawnRate > 0.1) {
      StartCoroutine(Spawn());
    }
    else {
      StopSpawning();
      var levelName = SceneManager.GetActiveScene().name;
      if (levelName == "SampleScreen") {
        SceneManager.LoadScene("Level2");
      }
    }
  }

  //private void StartSpawning() { InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); }

  public void StopSpawning() { CancelInvoke(nameof(Spawn)); }

}
