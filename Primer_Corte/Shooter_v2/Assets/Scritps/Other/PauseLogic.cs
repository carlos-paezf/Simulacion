using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseLogic : MonoBehaviour {

    public WeaponLogic[] weaponLogics;
    
    void Start() { }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
        }
    }

    public void PauseGame() {
        if (Time.timeScale == 1) {
            Time.timeScale = 0;
            Cursor.visible = true;
            for (int i = 0; i < weaponLogics.Length; i++) {
                WeaponLogic weaponLogic = weaponLogics[i];
                weaponLogic.canShoot = false;
            }
        }
        else {
            Time.timeScale = 1;
            Cursor.visible = false;
            for (int i = 0; i < weaponLogics.Length; i++) {
                WeaponLogic weaponLogic = weaponLogics[i];
                weaponLogic.canShoot = true;
            }
        }
       
    }

}
