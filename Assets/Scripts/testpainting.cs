using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpainting : MonoBehaviour {

    public Transform baseDot;
    public GameObject ob;

    public int i = 2;
    public float destsec = 0.3f;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {

        StartCoroutine("Makedot");

	}

    IEnumerator Makedot() 
    {
        Vector3 objPosition = ob.transform.position;
        Instantiate(baseDot, objPosition, baseDot.rotation);
        yield return new WaitForSeconds(2f);
    }


}
