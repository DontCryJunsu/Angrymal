using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waving : MonoBehaviour
{

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
                transform.Translate(0, 0.1f, 0);
            }

            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.05f);
                transform.Translate(0, 0.05f, 0);
            }
            for (int i = 0; i < 25; i++)
            {
                yield return new WaitForSeconds(0.05f);
                transform.Translate(0, -0.1f, 0);
            }
            for (int i = 0; i < 10; i++)
            {
                yield return new WaitForSeconds(0.05f);
                transform.Translate(0, -0.05f, 0);
            }

        }

    }
}
