﻿using System.Collections;
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
    public NavMeshAgent nav;
    public Transform loadZone;
    public bool act = true;

    public void Select()
    {
        if (LobbyManager.aniNum != null && LobbyManager.cNum ==0)
        {
            LobbyManager.loadAni++;
            nav = gameObject.GetComponentInParent<NavMeshAgent>();
            nav.enabled = true;
            nav.SetDestination(loadZone.transform.position);
            LobbyManager.esc = true;
            act = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // swit == 1인 상태 즉 캐릭터 선택 줌 상태일때 esc를 누르면
        if (LobbyManager.cNum == 0 && Input.GetKeyDown("escape") && LobbyManager.aniNum == gameObject.name || LobbyManager.esc && LobbyManager.aniNum == gameObject.name )
        {
            ZoomVC.GetComponent<CinemachineVirtualCamera>().LookAt = null;
            ZoomVC.GetComponent<CinemachineVirtualCamera>().Priority = 9;
            LobbyManager.aniNum = null;
            StartCoroutine(dUp());
            StartCoroutine(sDown());
            LobbyManager.esc = false;
        }
    }

    void OnMouseUp()
    {
        // 캐릭터 선택할시
        if (LobbyManager.aniNum == null && LobbyManager.loadAni < 3 && act == true)
        {
            ZoomVC.GetComponent<CinemachineVirtualCamera>().LookAt = transform;
            ZoomVC.GetComponent<CinemachineVirtualCamera>().Priority = 11;
            LobbyManager.aniNum = gameObject.name;
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
