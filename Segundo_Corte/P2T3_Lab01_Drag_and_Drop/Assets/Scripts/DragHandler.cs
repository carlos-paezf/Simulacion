using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

  public static GameObject ItemDragging;
  
  private Vector3   _startPosition;
  private Transform _startParent;
  private Transform _dragParent;


  void Start() {
    _dragParent = GameObject.FindGameObjectWithTag("DragParent").transform;
  }
  
  public void OnBeginDrag(PointerEventData eventData) {
    // This method is executed when the item is grabbed
    Debug.Log("OnBeginDrag");
    ItemDragging   = gameObject;
    var transform1 = transform;
    _startPosition = transform1.position;
    _startParent   = transform1.parent;
    transform.SetParent(_dragParent);
  }

  public void OnDrag(PointerEventData eventData) {
    // This method is executed every frame while dragging the item
    Debug.Log("OnDrag");
    transform.position = Input.mousePosition;
  }
  
  public void OnEndDrag(PointerEventData eventData) {
    // This method is executed when the item is dropped
    Debug.Log("OnEndDrag");
    ItemDragging = null;
    if (transform.parent == _dragParent) {
      transform.position = _startPosition;
      transform.SetParent(_startParent);
    }
  }
}
