using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public List<WeaponController> startingWeapons= new List<WeaponController>();

    public Transform weaponParentSocket;
    public Transform defaultWeaponPosition;
    public Transform aimingPosition;
    
    public int activeWeaponIndex { get; private set; }
    
    private WeaponController[] weaponSlots = new WeaponController[5];
    
    void Start() {
        Cursor.visible    = false;
        activeWeaponIndex = -1;
        foreach (WeaponController startingWeapon in startingWeapons) {
            AddWeapon(startingWeapon);
        }
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            SwitchWeapon(0);
        }
    }

    private void SwitchWeapon(int p_weaponIndex) {
        if (p_weaponIndex != activeWeaponIndex && p_weaponIndex >= 0) {
            weaponSlots[p_weaponIndex].gameObject.SetActive(true);
            activeWeaponIndex = p_weaponIndex;
            
            EventManager.current.NewGun.Invoke();
        }
    }
    
    private void AddWeapon(WeaponController p_weaponPrefab) {
        weaponParentSocket.position = defaultWeaponPosition.position;
        // Añadir un arma, pero no mostrarla
        for (int i = 0; i < weaponSlots.Length; i++) {
            if (weaponSlots[i] == null) {
                WeaponController weaponClone = Instantiate(p_weaponPrefab, weaponParentSocket);
                weaponClone.owner = gameObject;
                weaponClone.gameObject.SetActive(false);
                weaponSlots[i] = weaponClone; 
                return;
            }
        }
    }
}
