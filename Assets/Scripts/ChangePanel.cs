using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePanel : MonoBehaviour {
    public GameObject myself;
    public GameObject c2;
    public GameObject c3;
    public GameObject myhighlight;
    public GameObject c1highlight;
    public GameObject c2highlight;
    public GameObject mypanel;
    public GameObject c1panel;
    public GameObject c2panel;


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
        myhighlight.SetActive(true);
        c1highlight.SetActive(false);
        c2highlight.SetActive(false);
        mypanel.SetActive(true);
        c1panel.SetActive(false);
        c2panel.SetActive(false);

    }
}
