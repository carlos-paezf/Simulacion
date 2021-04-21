using UnityEngine;

public class Inventory : MonoBehaviour {

    public  GameObject   inventory;
    public  GameObject   slotHolder;
    private bool         _inventoryEnable;
    private int          _allSlots;
    private int          _enableSlots;
    private GameObject[] _slot;
    

    void Start() {
        _allSlots = slotHolder.transform.childCount;
        _slot = new GameObject[_allSlots];
        for (int i = 0; i < _allSlots; i++) {
            _slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (_slot[i].GetComponent<Slot>().item == null) {
                _slot[i].GetComponent<Slot>().empty = true;
            }
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            _inventoryEnable = !_inventoryEnable;
        }
        inventory.SetActive(_inventoryEnable);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Item") {
            GameObject itemPickedUp = other.gameObject;
            Item       item         = itemPickedUp.GetComponent<Item>();
            AddItem(itemPickedUp, item.id, item.type, item.description, item.icon);
        }
    }

    private void AddItem(GameObject itemObject, int itemID, string itemType, string itemDescription, Sprite itemIcon) {
        for (var i = 0; i < _allSlots; i++) {
            if (_slot[i].GetComponent<Slot>().empty) {
                itemObject.GetComponent<Item>().pickedUp  = true;
                _slot[i].GetComponent<Slot>().item        = itemObject;
                _slot[i].GetComponent<Slot>().id          = itemID;
                _slot[i].GetComponent<Slot>().type        = itemType;
                _slot[i].GetComponent<Slot>().description = itemDescription;
                _slot[i].GetComponent<Slot>().icon        = itemIcon;
                
                itemObject.transform.parent = _slot[i].transform;
                itemObject.SetActive(false);
                
                _slot[i].GetComponent<Slot>().UpdateSlot();
                _slot[i].GetComponent<Slot>().empty = false;
            }
            return;
        }
    }
}
