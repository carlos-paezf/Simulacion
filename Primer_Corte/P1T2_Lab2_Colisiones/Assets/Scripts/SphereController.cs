using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Attributes
    public float speed = 0.1f;
    public float timeReaining = 10;
    private int numberBox = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeReaining > 0)
        {
            timeReaining -= Time.deltaTime;
            Move();
        }
        
        Debug.Log("Time: " + timeReaining);
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Debug.Log("El usuario presiona tecla arriba");
            transform.Translate(new Vector3(0, 0, speed));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Debug.Log("El usuario presiona tecla arriba");
            transform.Translate(new Vector3(0, 0, -speed));
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Debug.Log("El usuario presiona tecla arriba");
            transform.Translate(new Vector3(speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // Debug.Log("El usuario presiona tecla arriba");
            transform.Translate(new Vector3(-speed, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("El usuario presiona tecla arriba");
            transform.Translate(new Vector3(0, speed/2, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log("Colision de Entrada");
        if (other.tag == "Caja")
        {
            Destroy(other.gameObject);
            this.numberBox++;
        }
    }

}
