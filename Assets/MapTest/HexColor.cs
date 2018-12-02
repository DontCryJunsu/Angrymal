using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexColor : MonoBehaviour
{
    public Material[] mt;
    Renderer rend;

    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = mt[0];
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "redcharacter")
        {
            rend.sharedMaterial = mt[1];
            transform.tag = "redteam";
        }
        else if (other.gameObject.tag == "bluecharacter")
        {
            rend.sharedMaterial = mt[2];
            transform.tag = "blueteam";
        }
    }
}
