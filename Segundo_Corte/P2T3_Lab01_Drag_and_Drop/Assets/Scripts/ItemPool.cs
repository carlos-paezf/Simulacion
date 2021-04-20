using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPool : MonoBehaviour, IDropHandler  {

  public void OnDrop(PointerEventData eventData) {
    DragHandler.ItemDragging.transform.SetParent(transform);
  }
}
