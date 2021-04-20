using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeScreen : MonoBehaviour {
  
  public TMP_Text currentLife;
  public Life     life;

  void Update() {
    currentLife.text = life.value.ToString();
    if (life.value > 75) {
      currentLife.color = Color.green;
    }else if (life.value <= 75 && life.value >= 25) {
      currentLife.color = Color.white;
    } else if (life.value < 25) {
      currentLife.color = Color.red;
    }
  }
}
