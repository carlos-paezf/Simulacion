using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void SceneChange(string nameScene) {
        SceneManager.LoadScene(nameScene);
    }

    public void Exit(){
        Application.Quit();
    }
}
