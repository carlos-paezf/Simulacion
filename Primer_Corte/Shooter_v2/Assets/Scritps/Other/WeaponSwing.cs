using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwing : MonoBehaviour {
  
  public  float   amount;
  public  float   maximumAmount;
  public  float   time;
  private Vector3 _initialPosition;
  public  bool    sways;
    
  void Start() {
    _initialPosition = transform.localPosition;
  }

  void Update() {
    sways = true;
    float movementX = Input.GetAxis("Mouse X") * amount;
    float movementY = Input.GetAxis("Mouse Y") * amount;
    movementX = Mathf.Clamp(movementX, -maximumAmount, maximumAmount);
    Vector3 finalPositionMovement = new Vector3(movementX, movementY, 0);
    if (Input.GetMouseButton(1)) {
      sways = false;
    }

    if (sways == true) {
      transform.localPosition = Vector3.Lerp(transform.localPosition, finalPositionMovement + _initialPosition,
              time * Time.deltaTime);
    }
  }
    
}
