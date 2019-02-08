using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffaloSkill : MonoBehaviour
{
    bool isSkill = false;
    public Material bufMat;
    public Material palete;
    public Renderer bufRen;

    public void skill()
    {
        if (!isSkill)
            StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        yield return null;
        isSkill = true;
        GetComponent<DefaultMove>().power += 20;
        bufRen.sharedMaterial = bufMat;
        yield return new WaitForSeconds(3f);
        GetComponent<DefaultMove>().power -= 20;
        bufRen.sharedMaterial = palete;
        yield return new WaitForSeconds(6f);
        isSkill = false;
    }
}
