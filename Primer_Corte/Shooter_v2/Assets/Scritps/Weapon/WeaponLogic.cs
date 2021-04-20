using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootingMode {
    SemiAuto,
    FullAuto
}

public class WeaponLogic : MonoBehaviour {

    protected Animator    animator;
    protected AudioSource audioSource;
    public    bool        timeNoShot = false;
    public    bool        canShoot   = false;
    public    bool        reloading  = false;

    [Header("Objects References")]
    public ParticleSystem gunFire;
    public Camera mainCamera;
    public Transform  triggerPoint;
    public GameObject damageEffectPrefab;

    [Header("Sounds References")]
    public AudioClip ShootSound;
    public AudioClip WithoutBulletsSound;
    public AudioClip CartridgeEnterSound;
    public AudioClip CartridgeOutSound;
    public AudioClip EmptySound;
    public AudioClip DrawSound;

    [Header("Weapon Attributes")]
    public ShootingMode shootingMode = ShootingMode.FullAuto;
    public float   damage = 20f;
    public float   rhythm = 0.3f;
    public int     remainingBullets;
    public int     bulletsInCartridge;
    public int     sizeCartridge  = 12;
    public int     maximumBullets = 100;
    public bool    isADS          = false;
    public Vector3 hipShot;
    public Vector3 ADS;
    public float   timeAim;
    public float   zoom;
    public float   normal;

    void Start() {
        Cursor.visible = false;

        audioSource        = GetComponent<AudioSource>();
        animator           = GetComponent<Animator>();
        bulletsInCartridge = sizeCartridge;
        remainingBullets   = maximumBullets;

        Invoke("EnableWeapon", 0.5f);
    }

    void Update() {
        if (shootingMode == ShootingMode.FullAuto && Input.GetButton("Fire1")) {
            CheckShoot();
        } else if (shootingMode == ShootingMode.SemiAuto && Input.GetButton(("Fire1"))) {
            CheckShoot();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            CheckReload();
        }
        
        if (Input.GetMouseButton(1)) {
            transform.localPosition = Vector3.Slerp(transform.localPosition, ADS, timeAim * Time.deltaTime);
            isADS                   = true;
            mainCamera.fieldOfView  = Mathf.Lerp(mainCamera.fieldOfView, zoom, timeAim * Time.deltaTime);
        }

        if (Input.GetMouseButtonUp(1)) {
            isADS = false;
        }

        if (isADS == false) {
            transform.localPosition = Vector3.Slerp(transform.localPosition, hipShot, timeAim * Time.deltaTime);
            mainCamera.fieldOfView  = Mathf.Lerp(mainCamera.fieldOfView, normal, timeAim * Time.deltaTime);
        }
    }

    void EnableWeapon() {
        canShoot = true;
    }
    
    void CheckShoot() {
        if (!canShoot) return;
        if (timeNoShot) return;
        if (reloading) return;
        if (bulletsInCartridge > 0) {
            Shoot();
        }
        else {
            WithoutBullets();
        }
    }
    
    void Shoot() {
        audioSource.PlayOneShot(ShootSound);
        timeNoShot = true;
        gunFire.Stop();
        gunFire.Play();
        PlayAnimationShoot();
        bulletsInCartridge--;
        StartCoroutine(RestartTimeNoShot());
        DirectShot();
    }

    void DirectShot() {
        RaycastHit hit;
        if (Physics.Raycast(triggerPoint.position, triggerPoint.forward, out hit)) {
            if (hit.transform.CompareTag("Enemy")) {
                Life life = hit.transform.GetComponent<Life>();
                if (life == null) {
                    throw new SystemException("No se encontro componente VidaEnemigo");
                }
                else {
                    life.TakeDamage(damage);
                    CreateDamageEffect(hit.point, hit.transform.rotation);
                }
            }
        }
    }
    
    public void CreateDamageEffect(Vector3 position, Quaternion rotation) {
        GameObject damageEffect = Instantiate(damageEffectPrefab, position, rotation);
        Destroy(damageEffect, 1f);
    }
    
    public virtual void PlayAnimationShoot() {
        if (gameObject.name == "Police9mm") {
            if (bulletsInCartridge > 1) {
                animator.CrossFadeInFixedTime("Fire", 0.1f);
            }
            else {
                animator.CrossFadeInFixedTime("FireLast", 0.1f);
            }
        }
        else {
            animator.CrossFadeInFixedTime("Fire", 0.1f);
        }
    }
    
    public void WithoutBullets() {
        audioSource.PlayOneShot(WithoutBulletsSound);
        timeNoShot = true;
        StartCoroutine(RestartTimeNoShot());
    }
    
    IEnumerator RestartTimeNoShot() {
        yield return new WaitForSeconds(rhythm);
        timeNoShot = false;
    }
    
    void CheckReload() {
        if (remainingBullets > 0 && bulletsInCartridge < sizeCartridge) {
            Reload();
        }
    }
    
    void Reload() {
        if (reloading) return;
        reloading = true;
        animator.CrossFadeInFixedTime("Reload", 0.1f);
    }
    
    void ReloadAmmunition() {
        int bulletsToReload  = sizeCartridge - bulletsInCartridge;
        int substractBullets = (remainingBullets >= bulletsToReload) ? bulletsToReload : remainingBullets;
        remainingBullets -= substractBullets;
        bulletsInCartridge  += bulletsToReload;
    }

    public void DrawOn() {
        audioSource.PlayOneShot(DrawSound);
    }

    public void CartridgeEnterOn() {
        audioSource.PlayOneShot(CartridgeEnterSound);
        ReloadAmmunition();
    }

    public void CartridgeOutOn() {
        audioSource.PlayOneShot(CartridgeOutSound);
    }

    public void EmptyOn() {
        audioSource.PlayOneShot(EmptySound);
        Invoke("RestartReload", 0.1f);
    }

    void RestartReload() {
        reloading = false;
    }
    
}
