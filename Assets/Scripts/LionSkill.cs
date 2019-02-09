using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSkill : MonoBehaviour
{
    public Material LionMat;
    public Material palete;
    public Renderer LionRen;
    bool isheal = false;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(6f);
            LionRen.sharedMaterial = palete;
            isheal = false;
            yield return new WaitForSeconds(3f);
            LionRen.sharedMaterial = LionMat;
            isheal = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "redcharacter"&& isheal)
        {
            other.GetComponent<DefaultMove>().speed = 0f;
        }
    }
}