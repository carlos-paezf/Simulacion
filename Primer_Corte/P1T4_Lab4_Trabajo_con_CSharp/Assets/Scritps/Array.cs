using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Array : MonoBehaviour
{
    public string[] names = new string[5];
    
    void Start()
    {
        names[0] = "Carlos";
        names[1] = "Emma";
        names[2] = "Nicolas";
        names[3] = "Maria";
        names[4] = "Juan";
        
        print(names[4]);
        print(names.Length);
    }

    
    void Update()
    {
        
    }
}
