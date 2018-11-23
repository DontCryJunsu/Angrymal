using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFootColor : MonoBehaviour {

    Animator ani;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.tag == "redteam")
        {
            ani.Play("YellowColor");
        }
        if (transform.tag == "blueteam")
        {
            ani.Play("BlueColor");
        }
    }
}
