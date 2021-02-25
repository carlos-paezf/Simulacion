using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float _live = 3;

    public void getShot()
    {
        _live--;
        if (_live <= 0)
        {
            Destroy(gameObject);
        }
    }
}
