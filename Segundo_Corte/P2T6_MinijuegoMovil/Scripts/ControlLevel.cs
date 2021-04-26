using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlLevel : MonoBehaviour {
    
    public void Level() {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }
}
