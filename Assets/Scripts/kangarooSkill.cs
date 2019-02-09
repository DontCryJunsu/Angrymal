using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kangarooSkill : MonoBehaviour
{
    bool isSkill = false;
    Vector3 vec = new Vector3(0, 0.1f, 0);
    public GameObject AB;
    IEnumerator Start()
    {
        while (true)
        {
            yield return null;
            for (int i = 0; i < 40; i++)
            {
                yield return new WaitForSeconds(0.01f);
                transform.position += vec;
            }
            AB.SetActive(true);
            for (int i = 0; i < 40; i++)
            {
                yield return new WaitForSeconds(0.01f);
                transform.position -= vec;
            }
            AB.SetActive(false);
            yield return new WaitForSeconds(2f);

        }
    }
}
