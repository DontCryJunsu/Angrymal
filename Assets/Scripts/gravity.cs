using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics.gravity = new Vector3(0, 0, 0); //중력 0
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
