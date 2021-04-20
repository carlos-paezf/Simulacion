using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform pathHolder;
    public Color lineColor;
    public Color sphereColor;
    private List<Vector3> nodes;

    private void OnDrawGizmos() {
        nodes = new List<Vector3>();
        foreach (Transform node in pathHolder) {
            Gizmos.color = sphereColor;
            Gizmos.DrawSphere(node.position, 0.3f);
            nodes.Add(node.position);
        }

        Vector3 startNode = nodes[0];
        for (int i = 0; i < nodes.Count; i++) {
            Gizmos.color = lineColor;
            Gizmos.DrawLine(startNode, nodes[i]);
            startNode = nodes[i];
        }
    }

    public List<Vector3> GETNODES {
        get {
            nodes = new List<Vector3>();
            foreach (Transform node in pathHolder) {
                nodes.Add(node.position);
            }
            return nodes;
        }
    }
}
