using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour
{
    public float waving = 0.05f;
    public float waving2 = 0.1f;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(wave());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator wave()
    {
        while (true)
        {
            for (int i = 0; i < 25; i++)
            {
                yield return new WaitForSeconds(0.05f);
                transform.Translate(0, waving2, 0);
            }

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.05f);
                transform.Translate(0, waving, 0);
            }
            for (int i = 0; i < 25; i++)
            {
                yield return new WaitForSeconds(0.05f);
                transform.Translate(0, -waving2, 0);
            }
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.05f);
                transform.Translate(0, -waving, 0);
            }

        }

    }
}
