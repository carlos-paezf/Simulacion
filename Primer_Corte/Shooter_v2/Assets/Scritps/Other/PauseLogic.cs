using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour {
    
    public WeaponLogic[] weaponLogics;
    public bool          gamePanel;

    public GameObject pausePanel, exitPanel;

    void Start() {
        pausePanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
           SwitchPause(); 
        }
    }
    
    public void SwitchPause() {
        if (gamePanel) {
            BtnResume();
        }
        else {
            BtnPause();
        }
    }

    void BtnPause() {
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        gamePanel      = true;
        Cursor.visible = true;
        if (Time.timeScale == 0) {
            for (int i = 0; i < weaponLogics.Length; i++) {
                WeaponLogic weaponLogic = weaponLogics[i];
                weaponLogic.canShoot = false;
            }
        }
    }
    
    void BtnResume() {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
        gamePanel      = false;
        Cursor.visible = false;
        if (Time.timeScale == 1) {
            for (int i = 0; i < weaponLogics.Length; i++) {
                WeaponLogic weaponLogic = weaponLogics[i];
                weaponLogic.canShoot = true;
            }
        }
        if (Time.timeScale == 0) {
            for (int i = 0; i < weaponLogics.Length; i++) {
                WeaponLogic weaponLogic = weaponLogics[i];
                weaponLogic.canShoot = false;
            }
        }
    }
    
    public void MainMenu(string mainMenu) {
        SceneManager.LoadScene(mainMenu);
    }

    public void ExitPanel() {
        exitPanel.SetActive(true);
    }

    public void ExitPanelNo() {
        exitPanel.SetActive(false);
    }

    public void ExitPanelYes() {
        Debug.Log("Has salido del juego");
        Application.Quit();
    }

}
