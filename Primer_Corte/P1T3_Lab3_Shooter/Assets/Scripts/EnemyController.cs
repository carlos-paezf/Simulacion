using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float            _live = 3;
    private PlayerController _playerController;

    private void Start() {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>(); 
    }

    public void getShot() {
        _live--;
        if (_live <= 0) {
            _playerController.UpScore();
            Destroy(gameObject);
        }
    }
}
