using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    
    private string _p1 = "Variable privada";
    public string p2 = "Variable publica";
    string _p3 = "Variable por defecto privada";
    private int _valorA = 2;
    public float valorB = 0.5f;
    public bool playing = true;
    public string nombre = "Nombre x";
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Impresión por Consola");
        print(_p1);
        print(_p3);
        PrintName(nombre);
        Multiply(_valorA, valorB);
    }

    // Update is called once per frame
    void Update()
    {
        print(playing);
    }
    
    void PrintName(string name){ 
        print("Se impreme el mensaje" + name);
    }

    public void Multiply(int valorA, float valorB){
        float c = valorA * valorB;
        print("Multiplicación = " + c);
    }
}
