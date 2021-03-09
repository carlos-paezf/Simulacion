using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour {

    private Quaternion originLocalRotation;
    
    void Start() {
        originLocalRotation = transform.localRotation;
    }

    void Update() {
        UpdateSway();
    }

    private void UpdateSway() {
        float t_xLookInput = Input.GetAxis("Mouse X");
        float t_yLookInput = Input.GetAxis("Mouse Y");
        // Calcular la rotación de las armas
        Quaternion t_xAngleAdjustment = Quaternion.AngleAxis(-t_xLookInput * 2.5f, Vector3.up);
        Quaternion t_yAngleAdjustment = Quaternion.AngleAxis(t_yLookInput * 2.5f, Vector3.right);
        Quaternion t_targetRotation   = originLocalRotation * t_xAngleAdjustment * t_yAngleAdjustment;
        // Rotar hacia la rotación del objetivo
        transform.localRotation = Quaternion.Lerp(transform.localRotation, t_targetRotation, Time.deltaTime * 10f);
    }
}
