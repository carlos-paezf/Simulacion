using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Component : MonoBehaviour
{
    
    
    void Start() {
        var rigidbodyComponent = GetComponent<Rigidbody>();
        rigidbodyComponent.useGravity = false;
        GetComponent<Renderer>().material.color = Color.red;
        
        var player = GetComponent<PlayerHealt>();
        for (int i = 0; i < 200; i++){
            player.lives -= 1;
            print(player.lives);
        }
    }

    
    void Update(){
        
    }
}
