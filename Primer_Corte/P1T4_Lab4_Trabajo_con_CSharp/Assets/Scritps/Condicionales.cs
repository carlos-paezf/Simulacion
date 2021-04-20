using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condicionales : MonoBehaviour
{
    public int score = 10;
    bool _killPlayer = false;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        if (score <= 0){
            print("Game Over");
            _killPlayer = true;
        } else {
            print("Continuad Jugando");
        }

        if (_killPlayer == true){
            Destroy(gameObject, 2f);
        }
    }
}
