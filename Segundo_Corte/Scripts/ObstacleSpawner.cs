using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour {
    
  public GameObject obstacle;
  public float      spawnRate;
  public float      maxPositionX;

  void Start(){ StartSpawning(); }
  
  // private void Update() { if (Input.GetKeyDown(KeyCode.A)) Spawn(); }

  private void Spawn() {
    var randomX       = Random.Range(-maxPositionX, maxPositionX);
    var spawnPosition = new Vector2(randomX, transform.position.y);
    Instantiate(obstacle, spawnPosition, Quaternion.identity);
  }

  public void StartSpawning() {
    InvokeRepeating(nameof(Spawn), 1f, spawnRate);
  }

  public void StopSpawning() {
    CancelInvoke(nameof(Spawn));
  }
}
