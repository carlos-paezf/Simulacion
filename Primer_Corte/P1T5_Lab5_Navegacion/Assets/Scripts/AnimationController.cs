using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class AnimationController : MonoBehaviour {
    
    public  bool         isRunning = false;
    private Animator     animator;
    //Animation States
    const string PARAMETER_RUN = "Run";
    
    
    //Atributos para calcular la distancia
    private enum Distance {
        Space, XYPlane
    }
    [SerializeField]
    private GameObject   object1;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    public  TMP_Text     distanceIndicator;
    [SerializeField]
    private Distance     distanceType;
    
    public  float        distance;
    private LineRenderer lineRenderer;

    void Start() {
        animator = GetComponent<Animator>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() {
        if (distance <= 15f) {
            isRunning = false;
        }
        else {
            isRunning = true;
        }
        animator.SetBool(PARAMETER_RUN, isRunning);
        Position();
    }

    void Position() {
        lineRenderer.SetPosition(0, object1.transform.position);
        lineRenderer.SetPosition(1, player.transform.position);

        switch (distanceType) {
            case Distance.Space:
                distance               = CalculateDistanceInSpace();
                distanceIndicator.text = "Distance in Space: " + distance.ToString();
                break;
            case Distance.XYPlane:
                distance               = CalculateDistanceXYPlane();
                distanceIndicator.text = "Distance in XY Plane: " + distance.ToString();
                break;
        }
    }
    
    float CalculateDistanceInSpace() {
        return Vector3.Distance(object1.transform.position, player.transform.position);
    }

    float CalculateDistanceXYPlane() {
        Vector2 v1 = new Vector2(object1.transform.position.x, gameObject.transform.position.y);
        Vector2 v2 = new Vector2(player.transform.position.x, player.transform.position.y);
        return Vector2.Distance(v1, v2);
    }
}
