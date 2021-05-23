using UnityEngine;

public class PauseController : MonoBehaviour {

    public GameObject pausePanel, exitPanel;
    private bool _pause;
    
    private void Start(){
        pausePanel.SetActive(false);
        exitPanel.SetActive(false);
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)) SwitchPause();
    }

    private void SwitchPause() {
        if (_pause) Resume();
        else Pause();
    }

    public void Pause() {
        _pause = true;
        pausePanel.SetActive(true);
    }

    public void Resume() {
        pausePanel.SetActive(false);
        _pause = false;
    }

    public void ExitSimulation() {
        exitPanel.SetActive(true);
    }

    public void NoExitSimulation() {
        exitPanel.SetActive(false);
    }
}
