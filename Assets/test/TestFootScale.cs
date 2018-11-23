using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFootScale : MonoBehaviour {
    float size;
	// Use this for initialization
	void Start () {
        size = Random.RandomRange(1f, 5f);
        gameObject.transform.localScale = new Vector3(size,size,1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
