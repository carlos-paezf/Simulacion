using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Attrobutes
    public Camera camera;
    private float _speedPlayer = 1.5f;
    private float _horizontal;
    private float _vertical;
    private float _speedHorizontal = 1.5f;
    private float _speedVertical = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MoveCamera();
    }

    public void Move(){ 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical"); 
        transform.Translate(_speedPlayer * Time.deltaTime*Vector3.forward * z); 
        transform.Translate(_speedPlayer * Time.deltaTime*Vector3.right * x);
    }

    public void MoveCamera()
    {
        _horizontal = _speedHorizontal * Input.GetAxis("Mouse X");
        _vertical = _speedVertical * Input.GetAxis("Mouse Y");
        transform.Rotate(0, _horizontal, 0);
        camera.transform.Rotate(-_vertical, 0, 0);
    }
}
