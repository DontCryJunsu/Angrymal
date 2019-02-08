using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSkill : MonoBehaviour
{
    bool isSkill = false;
    public Material mouseMat;
    public Material palete;
    public Renderer mouseRen;

    public void skill()
    {
        if (!isSkill)
            StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        yield return null;
        isSkill = true;
        GetComponent<DefaultMove>().speed += 12;
        mouseRen.sharedMaterial = mouseMat;
        yield return new WaitForSeconds(6f);
        GetComponent<DefaultMove>().speed -= 12;
        mouseRen.sharedMaterial = palete;
        yield return new WaitForSeconds(6f);
        isSkill = false;
    }
}
