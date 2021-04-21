using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler {

    public GameObject item;
    public int        id;
    public string     type;
    public string     description;
    public bool       empty;
    public Sprite     icon;
    public Transform  slotIconGameObject;

    private void Start() {
        slotIconGameObject = transform.GetChild(0);
    }

    public void UpdateSlot() {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

    private void UseItem() {
        item.GetComponent<Item>().ItemUsage();
    }

    public void OnPointerClick(PointerEventData pointerEventData) {
        UseItem();
    }
}
