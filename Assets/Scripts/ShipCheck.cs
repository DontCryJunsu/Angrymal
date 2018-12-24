using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShipCheck : MonoBehaviour {


    PhotonView pv;
    public Transform ready;
    public Text txt;

    void Awake()
    {
        pv = GetComponent<PhotonView>();
        ready = GameObject.Find("RPCPan").transform;
        GameObject.Find("RPCText").GetComponent<Text>().text = "플레이어를 기다리는 중입니다.";
    }

    void OnTriggerEnter(Collider other)
    {
        if(pv.isMine && PlayerPrefs.GetString("Team").Equals("B") && other.transform.name.Equals("sea"))
        {
            RPCDown();
            pv.RPC("RPCDown", PhotonTargets.Others, null);
        }
    }

    IEnumerator dDown()
    {
        GameObject.Find("RPCText").GetComponent<Text>().text = "게임이 곧 시작됩니다.";
        yield return new WaitForSeconds(2f);

        GameObject.Find("RPCText").GetComponent<Text>().text = " 3 ";
        yield return new WaitForSeconds(1f);

        GameObject.Find("RPCText").GetComponent<Text>().text = " 2 ";
        yield return new WaitForSeconds(1f);

        GameObject.Find("RPCText").GetComponent<Text>().text = " 1 ";
        yield return new WaitForSeconds(1f);


        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            ready.Translate(0, -7f, 0);
        }
        yield return null;
    }

    [PunRPC]
    void RPCDown()
    {
        StartCoroutine(dDown());
    }
}
