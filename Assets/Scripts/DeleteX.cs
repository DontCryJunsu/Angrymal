using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteX : MonoBehaviour
{
    public void xBtn()
    {
        StartCoroutine(sDown());
    }

    IEnumerator sDown()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            transform.Translate(16f, 0, 0);
        }
        LobbyManager.cNum = 0;
        yield return null;
    }
}
