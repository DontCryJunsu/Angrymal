using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elephantSkill : MonoBehaviour
{
    bool isSkill = false;
    public GameObject part;
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
        part.SetActive(true);
        yield return new WaitForSeconds(10f);
        part.SetActive(false);
        SC.enabled = false;
        yield return new WaitForSeconds(4f);
        isSkill = false;
    }
}
