using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfSkill : MonoBehaviour
{
    bool isSkill = false;
    public Material wolfMat;
    public Material palete;
    public Renderer wolfRen;

    public void skill()
    {
        if (!isSkill)
            StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        float HP = GetComponent<DefaultMove>().hp;
        isSkill = true;
        yield return null;
        wolfRen.sharedMaterial = wolfMat;
        yield return new WaitForSeconds(2f);
        GetComponent<DefaultMove>().hp = HP;
        wolfRen.sharedMaterial = palete;
        yield return new WaitForSeconds(4f);
        isSkill = false;
    }
}
