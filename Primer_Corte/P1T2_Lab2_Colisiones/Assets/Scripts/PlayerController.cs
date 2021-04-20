using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Attrobutes
    public float horizontal;
    public float vertical;
    public float speedHorizontal = 1.5f;
    public float speedVertical = 1.5f;
    public Camera camera;
    public float speedPlayer = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){
        horizontal = speedHorizontal * Input.GetAxis("Mouse X");
        vertical = speedVertical * Input.GetAxis("Mouse Y");
        transform.Rotate(0, horizontal, 0);
        camera.transform.Rotate(-vertical, 0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, speedPlayer));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -speedPlayer));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speedPlayer, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speedPlayer, 0, 0));
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(new Vector3(0, speedPlayer, 0));
        }
    }
}
