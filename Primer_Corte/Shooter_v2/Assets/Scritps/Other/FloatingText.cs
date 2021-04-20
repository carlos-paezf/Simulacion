using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour{
  
  public Camera  _camera;
  public float   timeOfLife = 1f;
  public Vector3 offset       = new Vector3(0, 1, 0);
    
    
  void Start() {
    _camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    Destroy(gameObject, timeOfLife);
    transform.localPosition += offset;
  }

  void Update() {
    transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward,
            _camera.transform.rotation * Vector3.up);
  }
}
