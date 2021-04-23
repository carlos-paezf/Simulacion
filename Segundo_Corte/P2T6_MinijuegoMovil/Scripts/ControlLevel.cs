using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlLevel : MonoBehaviour {
    
    public void Level() {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
}
