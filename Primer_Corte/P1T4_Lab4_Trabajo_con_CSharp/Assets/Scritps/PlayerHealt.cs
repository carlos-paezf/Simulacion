using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealt : MonoBehaviour
{
    public int lives = 10;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        if (lives <= 0){
            Destroy(gameObject);
        }
    }
}
