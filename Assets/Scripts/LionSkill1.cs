using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSkill1 : MonoBehaviour
{
    public Material LionMat;
    public Material palete;
    public Renderer LionRen;
    bool isheal = false;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            LionRen.sharedMaterial = palete;
            isheal = false;
            yield return new WaitForSeconds(3f);
            LionRen.sharedMaterial = LionMat;
            isheal = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "bluecharacter"&& isheal)
        {
            other.GetComponent<DefaultMove>().speed = 0f;
        }
    }
}