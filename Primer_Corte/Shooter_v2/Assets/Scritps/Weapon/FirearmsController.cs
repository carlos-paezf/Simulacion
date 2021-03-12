using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirearmsController : MonoBehaviour
{
    public  WeaponLogic[] weapons;
    private int           currentWeaponIndex = 0;
    
    
    void Start() { }

    // Update is called once per frame
    void Update() {
        CheckWeaponChange();
    }

    private void ChangeCurrentWeapon() {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }
    private void CheckWeaponChange() {
        float mouseWheel = Input.GetAxis("Mouse ScrollWheel");
        if (mouseWheel > 0f) {
            SelectPreviousWeapon();
            weapons[currentWeaponIndex].reloading  = false;
            weapons[currentWeaponIndex].timeNoShot = false;
            weapons[currentWeaponIndex].isADS      = false;
        } else if (mouseWheel < 0f) {
            SelectNextWeapon();
            weapons[currentWeaponIndex].reloading  = false;
            weapons[currentWeaponIndex].timeNoShot = false;
            weapons[currentWeaponIndex].isADS      = false;

        }
    }

    private void SelectPreviousWeapon() {
        if (currentWeaponIndex == 0) {
            currentWeaponIndex = weapons.Length - 1;
        }
        else {
            currentWeaponIndex--;
        }
        ChangeCurrentWeapon();
    }

    private void SelectNextWeapon() {
        if (currentWeaponIndex >= (weapons.Length-1)) {
            currentWeaponIndex = 0;
        }
        else {
            currentWeaponIndex++;
        }
        ChangeCurrentWeapon();
    }
}
