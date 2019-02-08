using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elephantSkill : MonoBehaviour
{
    bool isSkill = false;
    public Material eleMat;
    public Material palete;
    public Renderer eleRen;
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
        SC.enabled = true;
        eleRen.sharedMaterial = eleMat;
        yield return new WaitForSeconds(8f);
        eleRen.sharedMaterial = palete;
        SC.enabled = false;
        yield return new WaitForSeconds(4f);
        isSkill = false;
    }
}
