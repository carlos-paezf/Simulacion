using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFox : MonoBehaviour
{
  private Transform  startMarker;
  private Vector3    endMarker;     
  private float      speed = 0.05F;     
  private float      startTime;     
  private float      journeyLength;     
  private Quaternion _lookRotation;     
  private Vector3    _direction;    
  private GameObject cameraPlayer;
  private Animator   foxAnim; 
 
  void Start() { 
    cameraPlayer  = GameObject.FindWithTag("MainCamera");         
    journeyLength = 0; 
    foxAnim       = GetComponent<Animator>();
    startMarker   = this.transform;
  }     
  
  void Update() { 
    if (journeyLength > 0) { 
      float distCovered = (Time.time - startTime) * speed;             
      float fracJourney = distCovered / journeyLength;
      transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
      if (fracJourney < 0.1) { 
        var lookPos  = endMarker - transform.position;                 
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
 
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f); 
      }         
    } 
    if (Vector3.Distance(startMarker.position, endMarker) < 0.1) { 
      foxAnim.SetBool("isWalking", false); 
    }     
  }

  public void StartMove(Vector3 endPos) {
    foxAnim.SetBool("isWalking", true);
    startMarker   = this.transform;
    endMarker     = endPos;
    startTime     = Time.time; 
    journeyLength = Vector3.Distance(startMarker.position, endMarker); 
    Debug.Log("Camino es " + journeyLength);
  }
}
