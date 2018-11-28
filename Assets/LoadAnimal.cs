using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LoadAnimal : MonoBehaviour {

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    bool C1 = false;
    bool C2 = false;
    bool C3 = false;
    GameObject animalUI;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "animal")
        {
            string NAME = other.gameObject.name + "UI";
            Destroy(other.gameObject);
            animalUI = GameObject.Find(NAME);
            StartCoroutine(sizeUp());
            if(C1 == false)
            {
                animalUI.transform.position = new Vector3(c1.transform.position.x, c1.transform.position.y + 10f, c1.transform.position.z);
                C1 = true;
            }
            else if(C2 == false)
            {
                animalUI.transform.position = new Vector3(c2.transform.position.x, c2.transform.position.y + 10f, c2.transform.position.z);
                C2 = true;
            }
            else if (C3 == false)
            {
                animalUI.transform.position = new Vector3(c3.transform.position.x, c3.transform.position.y + 10f, c3.transform.position.z);
                C3 = true;
            }
        }
    }

    IEnumerator sizeUp()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.02f);
            animalUI.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.01f);
            animalUI.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.02f);
            animalUI.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }
        yield return null;
    }

}
