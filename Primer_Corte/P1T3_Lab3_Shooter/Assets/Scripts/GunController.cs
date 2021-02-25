using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera _camera;
    private float _range = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // Recibir la entrad del Click
        if (Input.GetButtonDown("Fire1"))
        {
            // Lanzar un vector(hit) desde la cámara hacia adelante hasta un determinado rango
            if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range))
            {
                // Si retorna verdadero (es decir, si choca con un objeto) haga esto:
                Debug.Log(hit.transform.name);
                EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.getShot();
                }
            }  
        }
    }
}
