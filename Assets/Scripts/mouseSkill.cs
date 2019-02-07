using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseSkill : MonoBehaviour
{
    bool isSkill = false;
    public void skill()
    {
        if (!isSkill)
            StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        isSkill = true;
        yield return null;
        GetComponent<DefaultMove>().speed = 16f;
        yield return new WaitForSeconds(3f);
        GetComponent<DefaultMove>().speed = 4f;
        isSkill = false;
    }
}
