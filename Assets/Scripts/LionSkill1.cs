using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSkill1 : MonoBehaviour
{
    public GameObject part;
    bool isheal = false;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f);
            part.SetActive(false);
            isheal = false;
            yield return new WaitForSeconds(3f);
            part.SetActive(true);
            isheal = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "bluecharacter" && isheal)
        {
            other.GetComponent<DefaultMove>().speed = 0f;
        }
    }
}