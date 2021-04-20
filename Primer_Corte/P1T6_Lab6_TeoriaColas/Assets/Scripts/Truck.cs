using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Truck
{
    private TruckPrefab truckPrefab;

    public Truck(TruckPrefab truckPrefab) {
        this.truckPrefab = truckPrefab;
    }

    public void MoveTo(Vector3 position, Action onArrivedAtPosition = null) {
        truckPrefab.MoveTo(position, onArrivedAtPosition);
    }

}
