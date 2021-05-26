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
   private Vector3 _moveInput     = Vector3.zero;
   private Vector3 _rotationInput = Vector3.zero;
   private float   _cameraVerticalAngle;

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
      _moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
      _moveInput = Vector3.ClampMagnitude(_moveInput, 1f);

      if (Input.GetButton("Sprint")) _moveInput = transform.TransformDirection(_moveInput) * runSpeed;
      else _moveInput = transform.TransformDirection(_moveInput) * walkSpeed;

      _moveInput.y += gravityScale * Time.deltaTime;
      _characterController.Move(_moveInput * Time.deltaTime);
   }

   private void Look() {
      _rotationInput.x = Input.GetAxis("Mouse X") * rotationSensibility * Time.deltaTime;
      _rotationInput.y = Input.GetAxis("Mouse Y") * (rotationSensibility * 0.7f) * Time.deltaTime;

      _cameraVerticalAngle += _rotationInput.y;
      _cameraVerticalAngle = Mathf.Clamp(_cameraVerticalAngle, -70, 70);
      
      transform.Rotate(Vector3.up * _rotationInput.x);
      playerCamera.transform.localRotation = Quaternion.Euler(-_cameraVerticalAngle, 0f, 0f);
   }
}