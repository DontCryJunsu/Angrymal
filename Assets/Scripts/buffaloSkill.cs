using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffaloSkill : MonoBehaviour
{
    public Rigidbody rgdy;
    void OnTriggerEnter(Collider other)
    {
        if (tag == "redattack")
        {
            if (other.tag == "bluecharacter")
            {
                Debug.Log("BS");
                rgdy.AddRelativeForce(Vector3.forward * 500f);
            }
        }
        else if (tag == "blueattack")
        {
            if (other.tag == "redcharacter")
            {
                Debug.Log("BS");
                rgdy.AddRelativeForce(Vector3.forward * 500f);
            }
        }
    }
}
