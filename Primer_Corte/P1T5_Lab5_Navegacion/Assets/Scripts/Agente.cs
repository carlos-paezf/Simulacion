using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agente : MonoBehaviour {
    
    public Transform    objetivo;
    public NavMeshAgent agente;
    
    void Start() {
        agente = GetComponent<NavMeshAgent>();
    }

    
    void Update() {
        agente.destination = objetivo.position;
    }
}
