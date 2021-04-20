using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour {

   [Header ("General")]
   private CharacterController _characterController;
   public float gravityScale = -40f;

   [Header ("References")] public Camera playerCamera;
   
   [Header ("Movement and Rotation")]
   Vector3 moveInput = Vector3.zero;
   Vector3 rotationInput = Vector3.zero;
   private float cameraVerticalAngle;

   [Header("Sensibility")] public float rotationSensibility = 150f;
   
   [Header ("Speed")]
   public float walkSpeed = 5f;
   public float runSpeed = 10f;
   
   [Header ("Jump")] public float jumpHeight = 1.9f;

   public void Awake() {
      _characterController = GetComponent<CharacterController>();
   }

   public void Update() {
      Move();
      Look();
   }

   private void Move() {
      // Si el player esta sobre el suelo ...
      if (_characterController.isGrounded) {
         
         moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
         // No importa se oprime 2 teclas de movimiento, siempre se movera en un vector entre 0 y 1
         moveInput = Vector3.ClampMagnitude(moveInput, 1f);
         
         /** Se requiere crear botón Sprint en Edit->Project Settings->Input Manager->Aumentar en uno Size,
          * y poner en el nuevo elemento en el campo de Positive Button: "left shift"
          */
         if (Input.GetButton("Sprint")) {
            moveInput = transform.TransformDirection(moveInput) * runSpeed;
         }
         else {
            moveInput = transform.TransformDirection(moveInput) * walkSpeed;
         }

         if (Input.GetButtonDown("Jump")) {
            moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravityScale);
         }
      }

      moveInput.y += gravityScale * Time.deltaTime;
      _characterController.Move(moveInput * Time.deltaTime);
   }

   private void Look()
   {
      rotationInput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
      rotationInput.y = Input.GetAxis("Mouse Y") * (rotationSensibility * 0.7f) * Time.deltaTime;

      cameraVerticalAngle += rotationInput.y;
      cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);
      
      transform.Rotate(Vector3.up * rotationInput.x);
      playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);
   }
}
