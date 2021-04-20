using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeObjectsLogic : MonoBehaviour {
   
    
    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            Ray        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo)) {
                if (hitInfo.collider.gameObject.tag == "Object" &&
                    hitInfo.collider.gameObject.GetComponent<ObjectLogic>().destroyWithCursor == true) {
                    Debug.Log(hitInfo.collider.gameObject.tag);
                    hitInfo.collider.gameObject.GetComponent<ObjectLogic>().Effect();
                    Destroy(hitInfo.collider.gameObject);
                }
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        Debug.Log(other.tag);
        if (other.tag == "Object" && other.GetComponent<ObjectLogic>().automaticallyDestroy == true) {
            other.GetComponent<ObjectLogic>().Effect();
            Destroy(other.gameObject);
        }

        if (other.tag == "Object") {
            if (Input.GetKeyDown(KeyCode.Q) && other.GetComponent<ObjectLogic>().destroyWithCursor == false) {
                other.GetComponent<ObjectLogic>().Effect();
                Destroy(other.gameObject);
            }
        }
    }
}
