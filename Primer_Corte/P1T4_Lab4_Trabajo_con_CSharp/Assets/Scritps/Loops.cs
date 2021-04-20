using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

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
        int i = 0;
        while(i > 10){
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(x, 0, 0);
            Thread.Sleep(2000);
            x += 3;
            i++;
        }
    }

    void UsoForEach() {
        foreach (GameObject oneGameObject in objects){
            objects[0].GetComponent<Renderer>().material.color = Color.black;
        }
    }
}
