using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D    _rb;
    private SpriteRenderer _sp;
    public  float          moveSpeed = 10;

    private void Awake() {
        _rb = GetComponent<Rigidbody2D>();
        _sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() {
      if (!Input.GetMouseButtonDown(0)) return;
      // ReSharper disable once PossibleLossOfFraction
      if (Input.mousePosition.x < Screen.width / 2) {
        _rb.velocity = Vector2.left * moveSpeed;
        _sp.flipX    = true;
      }
      else {
        _rb.velocity = Vector2.right * moveSpeed;
        _sp.flipX    = false;
      }
    }
}
