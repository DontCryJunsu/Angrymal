using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueRPC : MonoBehaviour
{
    private PhotonView pv;
    public Material[] mt;
    Renderer wallRend;
    GameObject ship;

    void Awake()
    {
        ship = GameObject.FindWithTag("ship");
        pv = GetComponent<PhotonView>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            if (col.transform.tag == "redteam" || col.transform.tag == "Untagged")
            {
                int num = int.Parse(col.transform.name);
                Blue(num);
                pv.RPC("Blue", PhotonTargets.Others, num);
            }
        }
    }

    [PunRPC]
    void Blue(int num)
    {
        ship.GetComponent<PhotonShip>().ServerBlue(num);
    }
}
