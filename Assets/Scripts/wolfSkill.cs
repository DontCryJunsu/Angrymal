using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfSkill : MonoBehaviour
{
    bool isSkill = false;
    public GameObject part;
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
        yield return null;
        isSkill = true;
        part.SetActive(true);
        wolfRen.sharedMaterial = wolfMat;
        yield return new WaitForSeconds(2.5f);
        GetComponent<DefaultMove>().hp = HP;
        part.SetActive(false);
        wolfRen.sharedMaterial = palete;
        yield return new WaitForSeconds(4f);
        isSkill = false;
    }
}
