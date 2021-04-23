using UnityEngine;

public class ObstacleController : MonoBehaviour {

  public float rotation;

  private void FixedUpdate() { transform.Rotate(0,0,rotation); }

  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      GameManager.Instance.GameOver();
      Destroy(other.gameObject);
    }

    if (!other.gameObject.CompareTag("Ground")) return;
    GameManager.Instance.IncrementScore();
    Destroy(gameObject);
  }
}
