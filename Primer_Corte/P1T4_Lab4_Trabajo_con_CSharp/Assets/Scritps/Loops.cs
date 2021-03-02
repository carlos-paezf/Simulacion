using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{
    public GameObject[] objects = new GameObject[4];
    
    void Start(){
        //UsoFor();
        //UsoWhile():

        objects[0] = GameObject.Find("Cube");
        objects[1] = GameObject.Find("Sphere");
        objects[2] = GameObject.Find("Capsule");
        objects[3] = GameObject.Find("Cylindre");
        
        //UsoForEach();
    }

    
    void Update(){
        
    }

    void UsoFor(){
        int x = -10;
        for (int i = 0; i < 5; i++){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            x = x + i;
            cube.transform.position = new Vector3(x, 0, -1);
        }
    }

    void UsoWhile(){
        int x = -10;
        int y = 2;
        while(x > y){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            x += 1;
            cube.transform.position = new Vector3(x, 0, -1);
        }
    }

    void UsoForEach() {
        foreach (GameObject oneGameObject in objects){
            objects[0].GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
