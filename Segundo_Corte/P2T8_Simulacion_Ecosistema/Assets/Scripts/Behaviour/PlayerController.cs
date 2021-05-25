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
   public  float               gravityScale = -40f;

   [Header ("References")]
   public Camera playerCamera;
   
   [Header ("Movement and Rotation")]
   private Vector3 moveInput     = Vector3.zero;
   private Vector3 rotationInput = Vector3.zero;
   private float   cameraVerticalAngle;

   [Header("Sensibility")]
   public float rotationSensibility = 150f;
   
   [Header ("Speed")]
   public float walkSpeed = 5f;
   public float runSpeed  = 10f;

   private void Awake() {
      _characterController = GetComponent<CharacterController>();
   }

   private void Update() {
      Move();
      Look();
   }

   private void Move() {
         
      moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
      moveInput = Vector3.ClampMagnitude(moveInput, 1f);

      if (Input.GetButton("Sprint")) moveInput = transform.TransformDirection(moveInput) * runSpeed;
      else moveInput = transform.TransformDirection(moveInput) * walkSpeed;

      moveInput.y += gravityScale * Time.deltaTime;
      _characterController.Move(moveInput * Time.deltaTime);
   }

   private void Look() {
      rotationInput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
      rotationInput.y = Input.GetAxis("Mouse Y") * (rotationSensibility * 0.7f) * Time.deltaTime;

      cameraVerticalAngle += rotationInput.y;
      cameraVerticalAngle = Mathf.Clamp(cameraVerticalAngle, -70, 70);
      
      transform.Rotate(Vector3.up * rotationInput.x);
      playerCamera.transform.localRotation = Quaternion.Euler(-cameraVerticalAngle, 0f, 0f);
   }
}