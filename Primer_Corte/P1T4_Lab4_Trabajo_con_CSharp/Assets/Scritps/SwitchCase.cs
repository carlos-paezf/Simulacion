using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCase : MonoBehaviour
{
    public int power;
    
    void Start()
    {
        
    }
    
    void Update(){
        UseSwitch();
    }

    void UseSwitch(){
        switch (power){
            case 1: print("Beginner Player");
                break;
            case 2: print("Intermediate Player");
                break;
            case 3: print("Advance Player");
                break;
            case 4: print("Master Player");
                break;
        }
    }
}
