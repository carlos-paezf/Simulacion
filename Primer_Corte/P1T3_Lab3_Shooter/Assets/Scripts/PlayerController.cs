using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Referencia de Camera")]
    public  Camera camera;
    
    [Header("Atributos Personaje")]
    private float  _speedPlayer = 1.5f;
    private float  _horizontal;
    private float  _vertical;
    private float  _speedHorizontal = 1.5f;
    private float  _speedVertical   = 1;
    
    [Header("Interfaz")]
    private int    _score           = 0;
    private UIManager _uiManager;
    
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        _uiManager = GameObject.Find("UIManagerCanvas").GetComponent<UIManager>();
    }
    
    void Update() {
        Move();
        MoveCamera();
    }

    private void Move() { 
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(_speedPlayer * Time.deltaTime * Vector3.forward * z);
        transform.Translate(_speedPlayer * Time.deltaTime * Vector3.right * x);
    }

    private void MoveCamera() {
        _horizontal = _speedHorizontal * Input.GetAxis("Mouse X");
        _vertical   = _speedVertical * Input.GetAxis("Mouse Y");
        transform.Rotate(0, _horizontal, 0);
        camera.transform.Rotate(-_vertical, 0, 0);
    }

    public void UpScore() {
        _score++;
        _uiManager.setScore(_score.ToString());
    }
}
