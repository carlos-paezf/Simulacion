using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovimientoEsfra : MonoBehaviour {
  
  public float velocidadPersonaje = 10f;
    void Start() {}

    void Update() {
      Move();
    }

    void Move() {
      float x = Input.GetAxis("Horizontal");
      float z = Input.GetAxis("Vertical");
      transform.Translate(velocidadPersonaje * Time.deltaTime * Vector3.forward * z );
      transform.Translate(velocidadPersonaje * Time.deltaTime * Vector3.right* x);

    }
}
