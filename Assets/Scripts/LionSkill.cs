using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSkill : MonoBehaviour
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
            yield return new WaitForSeconds(8f);
            part.SetActive(true);
            isheal = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "redcharacter"&& isheal)
        {
            other.GetComponent<DefaultMove>().speed = 0f;
            other.GetComponent<DefaultMove>().power = 1f;
        }
    }
}