using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public void LoadScene(string nameScene) {
        SceneManager.LoadScene(nameScene);
    }

    public void Exit(){
        Application.Quit();
    }

}
