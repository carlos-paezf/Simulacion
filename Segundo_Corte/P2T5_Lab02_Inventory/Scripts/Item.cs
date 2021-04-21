using UnityEngine;

public class Item : MonoBehaviour {
    public int    id;
    public string type;
    public string description;
    public Sprite icon;
    
    [HideInInspector]
    public bool   pickedUp;
    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    public GameObject weaponManager;
    [HideInInspector]
    public GameObject weapon;

    public bool playersWeapon;

    private void Start() {
        weaponManager = GameObject.FindWithTag("WeaponManager");
        if (!playersWeapon) {
            int allWeapons = weaponManager.transform.childCount;
            for (int i = 0; i < allWeapons; i++) {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().id == id) {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update() {
        if (equipped) {
            if (Input.GetKeyDown(KeyCode.E)) {
                equipped = false;
            }
            if (equipped == false) {
                gameObject.SetActive(false);
            }
        }
    }

    public void ItemUsage() {
        if (type == "Weapon") {
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipped = true;
        }
    }
}
