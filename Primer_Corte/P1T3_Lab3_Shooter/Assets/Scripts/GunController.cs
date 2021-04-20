using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public  Camera _camera;
    private float  _range = 200;
    public  int    numberBullets;
    private int    _maxNumberRecharge = 2;
    private bool   charging           = false;
    
    void Update()
    {
        // Recibir la entrad del Click
        if (Input.GetButtonDown("Fire1") && numberBullets > 0) {
            Shot();
        }

        if (Input.GetKeyDown(KeyCode.R) && (!charging) ) {
            charging = true;
            StartCoroutine("Recharge");

        }
    }

    private void Shot() {
        RaycastHit hit;
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

            numberBullets--;
        }
    }

    IEnumerator Recharge() {
        yield return new WaitForSeconds(2);
        numberBullets = _maxNumberRecharge;
        charging      = false;
    }
}
