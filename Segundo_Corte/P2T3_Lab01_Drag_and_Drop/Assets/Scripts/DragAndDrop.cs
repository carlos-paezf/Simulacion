using UnityEngine;

public class DragAndDrop : MonoBehaviour {

    private bool _isDragging;

    public void OnMouseDown() {
        _isDragging = true;
    }

    public void OnMouseUp() {
        _isDragging = false;
    }
    
    void Update() {
        if (_isDragging) {
            if (Camera.main is { }) {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                transform.Translate(mousePosition);
            }
        }
    }
}
