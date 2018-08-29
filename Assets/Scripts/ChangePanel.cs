using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour {
    public GameObject myself;
    public GameObject c2;
    public GameObject c3;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changecanvas() {

        myself.SetActive(true);
        c2.SetActive(false);
        c3.SetActive(false);

    }
}
