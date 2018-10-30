using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefaultMove : MonoBehaviour {

    public float runSpeed;
    public GameObject goal;
    NavMeshAgent nav;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.speed = runSpeed;

    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        nav.SetDestination(goal.transform.position);
	}
}
