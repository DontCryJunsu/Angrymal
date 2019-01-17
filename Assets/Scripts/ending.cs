using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    public GameObject upPan;
    public GameObject downPan;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            downPan.transform.Translate(29.3f, 0, 0);
            upPan.transform.Translate(-29.3f, 0, 0);
        }
        yield return null;
    }
}
