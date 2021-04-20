using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaración de Variables. Public mientras pruebas, luego pasar a private
    private float _inputVertical;         // Entrada de arriba y abajo
    private float _inputHorizontal;       // Entrada de derecha e izquierda
    public float speed = 25;
    public float timeRemaining = 20;
    private bool _gameOver = false;
    private bool _winner = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Validation();
    }

    public void Move()
    {
        
        //this.transform.Translate(0, 0, 0.5f);
        _inputVertical = Input.GetAxis("Vertical");
        _inputHorizontal = Input.GetAxis("Horizontal");
        /*
            * v = x / t
            * x = v * t            x = velocity * (Time.deltaTime)
        */
        this.transform.Translate(speed * Time.deltaTime * Vector3.forward * _inputVertical);
        this.transform.Translate(speed * Time.deltaTime * Vector3.right * _inputHorizontal);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Energy":
                Destroy(other.gameObject);
                timeRemaining = timeRemaining + 3;
                Debug.Log("-------------------------------------- Has ganado 3 segundos");
                _gameOver = false;
                break;
            case "Obstacle":
                if (timeRemaining > 0)
                {
                    Destroy(other.gameObject);
                    Debug.Log("-------------------------------------- CHOCASTE-> Te quito 4 segundos");
                    timeRemaining = timeRemaining - 4;
                }
                else
                {
                    _gameOver = true;
                }
                break;
            case "End":
                _gameOver = true;
                _winner = true;
                break;
        }
    }

    private void Validation()
    {
        if (timeRemaining > 0 && _gameOver == false)
        {
            timeRemaining -= Time.deltaTime;
            Move();
            Debug.Log("Time: " + timeRemaining);
        }
        if (timeRemaining > 0 && _gameOver == true && _winner == true)
        {
            Debug.Log("-------------------------------------- Has ganado... FELICITACIONES !!!");
        }
        if (timeRemaining < 0 && _gameOver == true && _winner == false)
        {
            Debug.Log("-------------- ¡¡¡ PERDISTE !!!");
        }
    }
}
