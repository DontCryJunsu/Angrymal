﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestination : MonoBehaviour {

    public GameObject chase;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cat" || other.tag == "wall")
        {
            UnityEngine.Debug.Log("goal");
            
            transform.position = new Vector3(Random.Range(-19, 19), 5, Random.Range(-30, 30));
           
            
        }
      
         
  
         
    }
    // Use this for initialization
    void Start () {
		  
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}