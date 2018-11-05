using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour {
    public string[] chicken = new string[2];
	// Use this for initialization

	void Start () {
        chicken[0] = "Always";           // 0번은 조건
        chicken[1] = "ChaseClosestEnemy";     // 1번은 행동
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }

/*
    public void test()
    {
        Debug.Log("test");
    }
    */
}
