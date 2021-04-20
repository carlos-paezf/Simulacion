using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private Text _score;

    void Start() {
        _score      = GameObject.Find("Score").GetComponent<Text>();
        _score.text = "";
    }
    
    public void setScore(string message) {
        _score.text = message;
    }
}
