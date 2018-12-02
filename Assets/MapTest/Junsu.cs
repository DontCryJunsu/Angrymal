using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Junsu : MonoBehaviour {
    public GameObject goal;
    NavMeshAgent nav;

    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update () {
        Debug.Log("asd");
        nav.SetDestination(goal.transform.position);
	}
}
