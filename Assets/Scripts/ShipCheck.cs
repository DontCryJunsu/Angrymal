using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipCheck : MonoBehaviour {

    int num=0;
    public Transform ready;
    public Text txt;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="ship")
        {
            num++;
        }
        if(num==2)
        {
            StartCoroutine(dDown());
        }
    }
    IEnumerator dDown()
    {
        txt.text = "게임이 곧 시작됩니다.";
        yield return new WaitForSeconds(2f);

        txt.text = " 3 ";
        yield return new WaitForSeconds(1f);

        txt.text = " 2 ";
        yield return new WaitForSeconds(1f);

        txt.text = " 1 ";
        yield return new WaitForSeconds(1f);


        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            ready.Translate(0, -7f, 0);
        }
        yield return null;
    }
}
