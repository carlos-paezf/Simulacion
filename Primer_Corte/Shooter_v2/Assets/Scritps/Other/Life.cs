using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {
    
  public float      value = 100;
  public Life       refInheritance;
  public float      damageMultiplier = 1.0f;
  public GameObject floatingTextPrefab;
  public float      totalDamage;

  public void TakeDamage(float damage) {
    damage *= damageMultiplier;
    if (refInheritance != null) {
      refInheritance.TakeDamage(damage);
      return;
    }

    totalDamage =  damage;
    value       -= damage;
    if (value >= 0) {
      ShowFloatingText();
    }
    if (value < 0) {
      value = 0;
      ShowFloatingText();
    }
  }

  private void ShowFloatingText() {
    var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
    go.GetComponent<TextMesh>().text = totalDamage.ToString();
    // go.GetComponent<TextMesh>().text = valor.ToString();
  }
  
}
