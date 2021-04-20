using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BulletsScreen : MonoBehaviour {
    
    public TMP_Text    currentBulletsText;
    public TMP_Text    totalBulletsText;
    public WeaponLogic weaponLogic;

    void Update() {
        currentBulletsText.text = weaponLogic.bulletsInCartridge.ToString() + "/" + weaponLogic.sizeCartridge.ToString();
        if (weaponLogic.bulletsInCartridge <= 0) {
            currentBulletsText.color = Color.red;
        }
        else {
            currentBulletsText.color = Color.white;
        }
        totalBulletsText.text = weaponLogic.remainingBullets.ToString();
    }
}
