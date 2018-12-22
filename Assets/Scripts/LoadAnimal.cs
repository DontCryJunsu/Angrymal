using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LoadAnimal : MonoBehaviour {

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public static bool C1 = false;
    public static bool C2 = false;
    public static bool C3 = false;
    GameObject animalUI;
    bool act = true;
    public GameObject X;

	void Update () {
		if(C1 == true && C2==true && C3==true)
        {
            X.SetActive(false);
        }
        else
        {
            X.SetActive(true);
        }
	}
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "animal" && act == true)
        {
            act = false;
            other.GetComponent<LobbyCam>().nav.enabled = false;
            string NAME = other.gameObject.name + "UI";
            other.gameObject.SetActive(false);
            other.GetComponentInParent<Transform>().transform.position = new Vector3(Random.Range(-20f, 40f), 7f, Random.Range(-60f, 40));
            animalUI = GameObject.Find(NAME);
            StartCoroutine(sizeUp());
            if(C1 == false)
            {
                PlayerPrefs.SetString("C1", NAME);
                animalUI.transform.position = new Vector3(c1.transform.position.x, c1.transform.position.y + 20f, c1.transform.position.z);
                C1 = true;
            }
            else if(C2 == false)
            {
                PlayerPrefs.SetString("C2", NAME);
                animalUI.transform.position = new Vector3(c2.transform.position.x, c2.transform.position.y + 20f, c2.transform.position.z);
                C2 = true;
            }
            else if (C3 == false)
            {
                PlayerPrefs.SetString("C3", NAME);
                animalUI.transform.position = new Vector3(c3.transform.position.x, c3.transform.position.y + 20f, c3.transform.position.z);
                C3 = true;
            }
        }
    }

    IEnumerator sizeUp()
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.02f);
            animalUI.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.01f);
            animalUI.transform.localScale += new Vector3(0.2f, 0.2f, 0);
        }
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.02f);
            animalUI.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        act = true;
        yield return null;
    }

}
