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

    // Use this for initialization
    void Awake()
    {
        rgdy = GetComponent<Rigidbody>();
        ot = GetComponent<Outline>();
        pv = GetComponent<PhotonView>();
        tr = GetComponent<Transform>();
        pv.synchronization = ViewSynchronization.UnreliableOnChange;
        pv.ObservedComponents[0] = this;

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
