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
                rgdy.isKinematic = false;
                for (int i = 0; i < 20; i++)
                {
                    rgdy.AddRelativeForce(Vector3.forward * 70f);
                }
            }
        }
        else if (tag == "blueattack")
        {
            if (other.tag == "redcharacter")
            {
                rgdy.isKinematic = false;
                for (int i = 0; i < 20; i++)
                {
                    rgdy.AddRelativeForce(Vector3.forward *70f);
                }
            }
        }
    }
}
