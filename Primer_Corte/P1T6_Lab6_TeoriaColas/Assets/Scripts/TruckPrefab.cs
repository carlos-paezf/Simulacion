using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TruckPrefab : MonoBehaviour
{
    private float speed = 15.0f;
    IEnumerator currentMoveCoroutine;
    public void MoveTo(Vector3 position, Action onArrivedAtPosition = null) {
        if (currentMoveCoroutine != null) {
            StopCoroutine(currentMoveCoroutine);
        }
        currentMoveCoroutine = Move(position, onArrivedAtPosition);
        StartCoroutine(currentMoveCoroutine);
    }
    private IEnumerator Move(Vector3 position, Action onArrivedAtPosition = null) {
        while (this.transform.position != position) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, position, speed * Time.deltaTime);
            yield return null;
        }
        onArrivedAtPosition?.Invoke();

    }
}
