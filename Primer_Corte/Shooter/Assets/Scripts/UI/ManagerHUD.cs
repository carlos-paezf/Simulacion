using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerHUD : MonoBehaviour {

  public GameObject weaponInfoPrefab;

  private void Start() {
    EventManager.current.NewGun.AddListener(CreateWeaponInfo);
  }

  public void CreateWeaponInfo() {
    Instantiate(weaponInfoPrefab, transform);
  }
}
