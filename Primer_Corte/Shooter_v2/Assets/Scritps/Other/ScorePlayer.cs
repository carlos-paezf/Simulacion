using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScorePlayer : MonoBehaviour {
    
    public float       value;
    public ScorePlayer valueScorePrefab;
    public TMP_Text    currentScore;
    
    void Start() {
        value = 0;
    }

    void Update()
    {
        currentScore.text = valueScorePrefab.value.ToString();   
    }
}
