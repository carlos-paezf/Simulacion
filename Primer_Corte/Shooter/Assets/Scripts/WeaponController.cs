using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    
    [Header("General")]
    public LayerMask hittableLayers;
    public  GameObject bulletHolePrefab;
    private Transform  cameraPlayerTransform;
    
    [Header("References")]
    public Transform weaponMuzzle; // Boquilla del arma

    [Header("Sounds & Visuals")]
    public GameObject flashEffect;

    [Header("Shoot Parameters")]
    public float fireRange = 200;
    public  float      recoildForce = 4f;   // Fuerza de Retroceso del arma
    public  float      fireRate     = 0.5f; // Intervalo entre disparos
    public  int        maxAmmo      = 12;   // Máx de munición
    public  int        currentAmmo { get; private set; }
    private float      lastTimeShoot = Mathf.NegativeInfinity;
    public  GameObject owner;

    [Header("Reload Parameters")]
    public float reloadTime = 1.5f;
    
    private void Awake() {
        currentAmmo = maxAmmo;
        EventManager.current.UpdateBulletsEvent.Invoke(currentAmmo, maxAmmo);
    }

    private void Start() {
        cameraPlayerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    
    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            TryShoot();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload());
        }
        
        // Regresar el arma a la posición inicial luego del retroceso
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0.1710944f,-1.799959f,-0.5145139f), Time.deltaTime * 5f);
    }

    private bool TryShoot() {
        if (lastTimeShoot + fireRate < Time.time) {
            if (currentAmmo >= 1) {
                HandleShoot();
                currentAmmo -= 1;
                EventManager.current.UpdateBulletsEvent.Invoke(currentAmmo, maxAmmo);
                return true;
            }
        }
        return false;
    }
    
    private void HandleShoot() {
        GameObject flashClone = Instantiate(flashEffect, weaponMuzzle.position, Quaternion.Euler(weaponMuzzle.forward), transform);
        Destroy(flashClone, 1f);
        AddRecoil();

        RaycastHit[] hits;
        hits = Physics.RaycastAll(cameraPlayerTransform.position, cameraPlayerTransform.forward, fireRange,
                        hittableLayers);
        foreach (RaycastHit hit in hits) {
            if (hit.collider.gameObject != owner) {
                GameObject bulletHoleClone = Instantiate(bulletHolePrefab, hit.point + hit.normal * 0.001f,
                                Quaternion.LookRotation(hit.normal));
                Destroy(bulletHoleClone, 4f);
            }
        }

        lastTimeShoot = Time.time;
    }

    private void AddRecoil() {
        transform.Rotate(-recoildForce, 0f, 0f);
        transform.position = transform.position - transform.forward * (recoildForce / 50f);
    }

    IEnumerator Reload() {
        /* TODO: Empezar la animación de recarga */
        Debug.Log("Recargando...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        EventManager.current.UpdateBulletsEvent.Invoke(currentAmmo, maxAmmo);
        Debug.Log("Recargada");
        /* TODO: Terminar la animación */
    }
}
