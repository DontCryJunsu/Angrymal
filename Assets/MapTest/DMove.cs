using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DMove : MonoBehaviour {
    NavMeshAgent nav;
    public GameObject goal;
    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(goal.transform.position);
	}
}
