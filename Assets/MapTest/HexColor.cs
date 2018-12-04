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
            if (tag == "Untagged")
            {
                Command.redtile++;
                rend.sharedMaterial = mt[1];
                transform.tag = "redteam";
            }
            else if (tag == "blueteam")
            {
                Command.redtile++;
                Command.bluetile--;
                rend.sharedMaterial = mt[1];
                transform.tag = "redteam";
            }
            //rend.sharedMaterial = mt[1];
            //transform.tag = "redteam";

        }
        else if (other.gameObject.tag == "bluecharacter")
        {
            if (tag == "Untagged")
            {
                Command.bluetile++;
                rend.sharedMaterial = mt[2];
                transform.tag = "blueteam";
            }
            else if (tag == "redteam")
            {
                Command.bluetile++;
                Command.redtile--;
                rend.sharedMaterial = mt[2];
                transform.tag = "blueteam";
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "redcharacter")
        {
            if (tag == "Untagged")
            {
                Command.redtile++;
                rend.sharedMaterial = mt[1];
                transform.tag = "redteam";
            }
            else if (tag == "blueteam")
            {
                Command.redtile++;
                Command.bluetile--;
                rend.sharedMaterial = mt[1];
                transform.tag = "redteam";
            }
        }
        else if (other.gameObject.tag == "bluecharacter")
        {
            if (tag == "Untagged")
            {
                Command.bluetile++;
                rend.sharedMaterial = mt[2];
                transform.tag = "blueteam";
            }
            else if (tag == "redteam")
            {
                Command.bluetile++;
                Command.redtile--;
                rend.sharedMaterial = mt[2];
                transform.tag = "blueteam";
            }
        }
    }
}
