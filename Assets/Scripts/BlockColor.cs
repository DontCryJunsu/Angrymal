using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockColor : MonoBehaviour {
    public GameObject block;

   
	// Use this for initialization
	void Start () {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        
        
        renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 0);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter(Collider other)
    {
        Renderer renderer = gameObject.GetComponent<Renderer>();
        if (other.gameObject.tag == "blueteam")
        {
            renderer.material.color = Color.blue;
            renderer.material.color = new Color(renderer.material.color.r, renderer.material.color.g, renderer.material.color.b, 255);
        }
    }
}
