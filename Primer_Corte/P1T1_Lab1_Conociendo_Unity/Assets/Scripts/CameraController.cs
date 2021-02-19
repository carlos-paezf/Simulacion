using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Atributos
    public GameObject player;               // En este caso, el vehiculo
    public Vector3 offset = new Vector3(0, 8, -10);         // Cámara respecto al player
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cameraPositioned();
    }

    public void cameraPositioned()
    {
        this.transform.position = player.transform.position + offset;
    }
}
