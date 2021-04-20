using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{
    private GameObject[] _enemies;
    void Start(){
        GameObject capsule1 = GameObject.Find("/Cube/Sphere/Capsule");
        capsule1.GetComponent<Renderer>().material.color = Color.black;

        /*
        var obj = GameObject.FindWithTag("Enemy");
        obj.GetComponent<Renderer>().material.color = Color.red;
        */
        _enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in _enemies) {
            enemy.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    
    void Update()
    {
        
    }
}
