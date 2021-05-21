using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{

    public void SceneChange(string nameScene) {
        SceneManager.LoadScene(nameScene);
    }

    public void Exit(){
        Application.Quit();
    }
}
