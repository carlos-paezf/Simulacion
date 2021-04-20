using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLogic : MonoBehaviour {

    public bool             destroyWithCursor;
    public bool             automaticallyDestroy;
    public PlayerLogic      playerLogic;
    public PlayerController playerController;
    public WeaponLogic      weaponLogic;
    public int              type;

    void Start() {
        playerLogic      = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerLogic>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        weaponLogic      = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponLogic>();
    }

    void Update() {
        weaponLogic = GameObject.FindGameObjectWithTag("Weapon").GetComponent<WeaponLogic>();
    }

    public void Effect() {
        switch (type) {
            case 1:
                playerLogic.life.value += 50;
                break;
            case 2:
                playerController.walkSpeed = playerController.walkSpeed * 2;
                playerController.runSpeed  = playerController.runSpeed * 2;
                break;
            case 3: 
                weaponLogic.remainingBullets = weaponLogic.maximumBullets;
                break;
            case 4:
                weaponLogic.damage     =  weaponLogic.damage * 2;
                playerLogic.life.value -= 50;
                break;
            default:
                Debug.Log("Sin efecto");
                break;
        }
    }
}
