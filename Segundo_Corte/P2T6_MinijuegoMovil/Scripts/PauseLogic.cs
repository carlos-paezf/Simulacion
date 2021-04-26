using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseLogic : MonoBehaviour {

    public GameObject panelPause, btnReset;
    
    private void Start() {
        panelPause.gameObject.SetActive(false);
        btnReset.gameObject.SetActive(false);
    }

    public void BtnPause() {
        panelPause.gameObject.SetActive(true);
        Time.timeScale = 0;
        btnReset.gameObject.SetActive(true);
    }
    
    public void BtnResume() {
        panelPause.gameObject.SetActive(false);
        btnReset.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void BtnExit() {
        Application.Quit();
    }

    public void BtnStart() {
        SceneManager.LoadScene("Level1");
    }
}
