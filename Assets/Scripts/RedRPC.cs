using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedRPC : MonoBehaviour
{
    private PhotonView pv;
    public Material[] mt;
    Renderer wallRend;
    public GameObject ship;

    void Awake()
    {
        ship = GameObject.FindWithTag("ship");
        pv = GetComponent<PhotonView>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            if (col.transform.tag == "blueteam" || col.transform.tag == "Untagged")
            {
                int num = int.Parse(col.transform.name);
                Red(num);
                pv.RPC("Red", PhotonTargets.Others, num);
            }
        }
    }

    [PunRPC]
    void Red(int num)
    {
        ship.GetComponent<PhotonShip>().ServerRed(num);
    }
}
