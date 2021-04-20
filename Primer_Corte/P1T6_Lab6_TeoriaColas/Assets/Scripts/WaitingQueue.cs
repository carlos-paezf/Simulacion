using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingQueue
{
    public List<Truck>   truckList { get; private set; }
    List<Vector3> positionList;
    Vector3       entrancePosition;

    public WaitingQueue(List<Vector3> positionList) {
        this.positionList = positionList;
        this.entrancePosition = positionList[positionList.Count - 1];
        truckList = new List<Truck>();
    }

    public bool CanAddTruck() {
        return truckList.Count < positionList.Count;
    }

    public void AddTruck(Truck truck) {
        truckList.Add(truck);
        truck.MoveTo(entrancePosition, () => {
            truck.MoveTo(positionList[truckList.IndexOf(truck)]);
        });
    }

    public Truck GetFirstInQueue() {
        if (truckList.Count == 0) {
            return null;
        }
        else {
            Truck truck = truckList[0];
            truckList.RemoveAt(0);
            RelocateAllTruck();
            return truck;
        }
    }

    public void RelocateAllTruck() {
        for (int i = 0; i < truckList.Count; i++) {
            Truck truck = truckList[i];
            truckList[i].MoveTo(positionList[i]);
        }
    }

}
