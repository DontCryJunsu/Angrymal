using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfSkill : MonoBehaviour
{
    bool isSkill = false;
    public Material wolfMat;
    public Material palete;
    public Renderer wolfRen;
    public SphereCollider SC;

    public void skill()
    {
        if (!isSkill)
            StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        isSkill = true;
        yield return null;
        wolfRen.sharedMaterial = wolfMat;
        SC.enabled = false;
        yield return new WaitForSeconds(3f);
        wolfRen.sharedMaterial = palete;
        SC.enabled = true;
        isSkill = false;
    }
}
