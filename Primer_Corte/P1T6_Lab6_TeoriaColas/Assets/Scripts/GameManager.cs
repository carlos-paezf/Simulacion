using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Path        path;
    [SerializeField] private TruckPrefab truckPrefab;
    WaitingQueue                         _waitingQueue;
    private int                          _counter;
    private int                          _numMaxTruck = 300;
    private int                          _countTruck;
    public Poisson poisson = new Poisson();

    void Start() {
        _waitingQueue = new WaitingQueue(path.GETNODES);
        
        float timeCreation  = Random.Range(1, 3);
        InvokeRepeating(nameof(CreationTruck), 0f, timeCreation);
        float timeAttention = Random.Range(1, 3);
        InvokeRepeating(nameof(CareTruck), 0f, timeAttention);
        poisson.InverseCdf();
        
    }
    
    void CreationTruck() {
        if (_waitingQueue.CanAddTruck()) {
            Debug.Log("Truck added into queue");
            TruckPrefab truckPrefab1 = Instantiate(truckPrefab);
            truckPrefab1.name = $"Truck {_counter++}";
            Truck truck = new Truck(truckPrefab1);
            _waitingQueue.AddTruck(truck);
        }
    }

    void CareTruck() {
        Truck truck = _waitingQueue.GetFirstInQueue();
        if (truck != null) {
            Debug.Log("Get truck in waiting queue");
            truck.MoveTo(new Vector3(0, 0, 0));
        }
    }


    private IEnumerator TruckIn() {
        while (_countTruck <= _numMaxTruck) {
            CreationTruck();
        }

        yield return new WaitForSeconds(5);
        _countTruck++;
    }
}
