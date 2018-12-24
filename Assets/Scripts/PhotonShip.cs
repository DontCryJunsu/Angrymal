using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonShip : MonoBehaviour
{

    private PhotonView pv = null;
    Outline ot;
    Rigidbody rgdy;
    private Transform tr;
    private Vector3 currPos = Vector3.zero;
    private Quaternion currRot = Quaternion.identity;

    public GameObject[] tile;

    public Material[] mt;
    Renderer wallRend;

    void Start()
    {
        tile = new GameObject[276];
        for (int i = 1; i <= 275; i++)
        {
            tile[i] = GameObject.Find(i.ToString());
        }
    }


    public void ServerRed(int num)
    {
        wallRend = tile[num].GetComponent<Renderer>();
        if (tile[num].transform.tag == "Untagged")
        {
            Command.redtile++;
            wallRend.sharedMaterial = mt[0];
            tile[num].transform.tag = "redteam";
        }
        else if (tile[num].transform.tag == "blueteam")
        {
            Command.redtile++;
            Command.bluetile--;
            wallRend.sharedMaterial = mt[0];
            tile[num].transform.tag = "redteam";
        }
    }
    public void ServerBlue(int num)
    {
        wallRend = tile[num].GetComponent<Renderer>();
        if (tile[num].transform.tag == "Untagged")
        {
            Command.bluetile++;
            wallRend.sharedMaterial = mt[1];
            tile[num].transform.tag = "blueteam";
        }
        else if (tile[num].transform.tag == "redteam")
        {
            Command.bluetile++;
            Command.redtile--;
            wallRend.sharedMaterial = mt[1];
            tile[num].transform.tag = "blueteam";
        }
    }

    // Use this for initialization
    void Awake()
    {
        rgdy = GetComponent<Rigidbody>();
        ot = GetComponent<Outline>();
        pv = GetComponent<PhotonView>();
        tr = GetComponent<Transform>();
        pv.synchronization = ViewSynchronization.UnreliableOnChange;
        pv.ObservedComponents[0] = this;

        if(PlayerPrefs.GetString("Team").Equals("R"))
        {
            ot.OutlineColor = new Color(1f, 0.3f, 0.3f, 1f);

        }
        else if (PlayerPrefs.GetString("Team").Equals("B"))
        {
            ot.OutlineColor = new Color(0.3f, 0.3f, 1f, 1f);

        }
        if (!pv.isMine)
        {
            rgdy.isKinematic = true;
        }

        currPos = tr.position;
        currRot = tr.rotation;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 플레이어의 위치 정보 송신
        if (stream.isWriting)
        {
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        }
        // 원격 플레이어의 위치 정보 수신
        else
        {
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.isMine)
        {
            ot.enabled = false;
            tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 3.0f);
            tr.rotation = Quaternion.Slerp(tr.rotation, currRot, Time.deltaTime * 3.0f);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("ESC");
            //PhotonNetwork.LeaveRoom();
        }
    }
}
