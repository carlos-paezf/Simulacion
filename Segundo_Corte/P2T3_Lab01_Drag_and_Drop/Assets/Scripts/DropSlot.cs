using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler {

    public GameObject item;
    
    void Update() {
        if (item != null && item.transform.parent != transform) {
            item = null;
        }
    }
    
    public void OnDrop(PointerEventData eventData) {
        if (!item) {
            item = DragHandler.ItemDragging;
            item.transform.SetParent(transform);
            item.transform.position = transform.position;
        }
    }
}
