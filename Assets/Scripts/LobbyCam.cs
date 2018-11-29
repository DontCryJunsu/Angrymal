using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;

public class LobbyCam : MonoBehaviour
{
    public GameObject WideVC;
    public GameObject ZoomVC;
    public Transform Downbar;
    public Transform Sidebar;
    NavMeshAgent nav;
    public Transform loadZone;
    public int aniNum;
    public void Select()
    {
        nav = gameObject.GetComponentInParent<NavMeshAgent>();
        nav.SetDestination(loadZone.transform.position);
        LobbyManager.esc = true;
    }

    // Update is called once per frame
    void Update()
    {
        // swit == 1인 상태 즉 캐릭터 선택 줌 상태일때 esc를 누르면
        if (Input.GetKeyDown("escape") && LobbyManager.aniNum == aniNum || LobbyManager.esc && LobbyManager.aniNum == aniNum)
        {
            ZoomVC.GetComponent<CinemachineVirtualCamera>().LookAt = null;
            ZoomVC.GetComponent<CinemachineVirtualCamera>().Priority = 9;
            LobbyManager.aniNum = 0;
            StartCoroutine(dUp());
            StartCoroutine(sDown());
            LobbyManager.esc = false;
        }
    }

    void OnMouseUp()
    {
        // 캐릭터 선택할시
        if (LobbyManager.aniNum == 0)
        {
            ZoomVC.GetComponent<CinemachineVirtualCamera>().LookAt = transform;
            ZoomVC.GetComponent<CinemachineVirtualCamera>().Priority = 11;
            LobbyManager.aniNum = aniNum;
            StartCoroutine(dDown());
            StartCoroutine(sUp());
        }
    }

    IEnumerator dDown()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Downbar.Translate(0, -7f, 0);
        }
        yield return null;
    }

    IEnumerator dUp()
    {
        for (int i = 0; i < 20; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Downbar.Translate(0, 7f, 0);
        }
        yield return null;
    }

    IEnumerator sDown()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Sidebar.Translate(16f, 0, 0);
        }
        yield return null;
    }

    IEnumerator sUp()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Sidebar.Translate(-16f, 0, 0);
        }
        yield return null;
    }
}
