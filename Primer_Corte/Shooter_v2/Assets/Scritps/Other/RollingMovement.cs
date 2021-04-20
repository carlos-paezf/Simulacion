using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollingMovement : MonoBehaviour {
  
  private float      timer         = 0.0f;
  public  float      bobbingSpeed  = 0.5f;
  public  float      bobbingAmount = 0.1f;
  public  float      midpoint;
  public  WeaponLogic weaponLogic;
    
    
  void Update() {
    float   waveslice        = 0.0f;
    float   horizontal       = Input.GetAxis("Horizontal");
    float   vertical         = Input.GetAxis("Vertical");
    Vector3 cSharpConversion = transform.localPosition;
        
    if (weaponLogic.isADS == false) {
      if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) {
        timer = 0.0f;
      }
      else {
        waveslice = Mathf.Sin(timer);
        timer     = timer + bobbingSpeed;
        if (timer > Mathf.PI * 2) {
          timer = timer - (Mathf.PI * 2);
        }
      }

      if (waveslice != 0) {
        if (Input.GetButton("Sprint")){
          float translateChange = waveslice * bobbingAmount * 2;
          float totalAxes       = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
          totalAxes          = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
          translateChange    = totalAxes * translateChange;
          cSharpConversion.y = midpoint + translateChange;
        }
        else {
          float translateChange = waveslice * bobbingAmount;
          float totalAxes       = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
          totalAxes          = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
          translateChange    = totalAxes * translateChange;
          cSharpConversion.y = midpoint + translateChange;
        }
      }
      else {
        cSharpConversion.y = midpoint;
      }

      transform.localPosition = cSharpConversion;
    }
  }
    
}
