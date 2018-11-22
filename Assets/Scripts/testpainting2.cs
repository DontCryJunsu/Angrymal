using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testpainting2 : MonoBehaviour
{

    public Transform baseDot;
    public GameObject ob;
    bool check = true;
    public int i = 2;
    public float destsec = 0.3f;
    public Transform Tf;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("Makedot");

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "redteam")
        {
            check = false;
        }
        if (other.tag == "blueteam")
        {
            //check = true;
            Destroy(other.gameObject);
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "redteam")
        {
            check = true;
            Debug.Log("Exit");
        }
    }
    // Update is called once per frame
    void Update()
    {


    }



    IEnumerator Makedot()
    {

        while (true)
        {
            Vector3 objPosition = new Vector3(ob.transform.position.x, ob.transform.position.y - 0.5f, ob.transform.position.z);

            if (check == true)
            {
                Instantiate(baseDot, objPosition, Tf.transform.rotation);
            }
            yield return null;
        }
    }


}
