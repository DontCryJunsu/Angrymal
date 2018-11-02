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
        StartCoroutine("JustWalk");
    }
	
	// Update is called once per frame
	void Update () {
       // nav.SetDestination(goal.transform.position);
	}

    IEnumerator JustWalk()
    {
        while (true)
        {
            yield return null;
            nav.SetDestination(goal.transform.position);  //goal 오브젝트를 향해 이동
        }
    }

}
