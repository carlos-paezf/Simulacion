using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Declaración de Variables. Public mientras pruebas, luego pasar a private
    public float inputVertical;         // Entrada de arriba y abajo
    public float inputHorizontal;       // Entrada de derecha e izquierda
    public float velocity = 25;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }

    public void movement()
    {
        //this.transform.Translate(0, 0, 0.5f);
        inputVertical = Input.GetAxis("Vertical");
        inputHorizontal = Input.GetAxis("Horizontal");
        /*
         * v = x / t
         * x = v * t            x = velocity * (Time.deltaTime)
         */
        this.transform.Translate(velocity * Time.deltaTime * Vector3.forward * inputVertical);
        this.transform.Translate(velocity * Time.deltaTime * Vector3.right * inputHorizontal);
    }
}
