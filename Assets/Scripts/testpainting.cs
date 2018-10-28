using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpainting : MonoBehaviour
{

    public Transform baseDot;
    public Transform catDot;
    public GameObject ob;
    bool check = true;
    public int i = 2;
    public float destsec = 0.3f;

    // Use this for initialization
    void Start()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blueteam")
        {
            check = false;
        }
        if (other.tag == "redteam")
        {
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "blueteam")
        {
            check = true;
        }
    }
    // Update is called once per frame
    void Update()
    {

        StartCoroutine("Makedot");

    }



    IEnumerator Makedot()
    {

        Vector3 objPosition = ob.transform.position;
        if (check == true)
            Instantiate(baseDot, objPosition, catDot.rotation);
        yield return new WaitForSeconds(2f);
    }


}
