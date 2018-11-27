using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LobbyCam : MonoBehaviour
{
    public GameObject WideVC;
    public GameObject ZoomVC;
    public Transform Downbar;
    public Transform Sidebar;
    public string name;
    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("escape") && LobbyManager.swit == 1 && LobbyManager.btnInt ==0)||LobbyManager.esc)
        {
            ZoomVC.GetComponent<CinemachineVirtualCamera>().LookAt = null;
            ZoomVC.GetComponent<CinemachineVirtualCamera>().Priority = 9;
            LobbyManager.swit = 0;
            StartCoroutine(dUp());
            StartCoroutine(sDown());
            LobbyManager.esc = false;
        }
    }

    void OnMouseUp()
    {
        if (LobbyManager.swit == 0)
        {
            LobbyData.Lobbyanimal = name;
            ZoomVC.GetComponent<CinemachineVirtualCamera>().LookAt = transform;
            ZoomVC.GetComponent<CinemachineVirtualCamera>().Priority = 11;
            LobbyManager.swit = 1;
            LobbyManager.name = name;
            StartCoroutine(dDown());
            StartCoroutine(sUp());
        }
    }

    IEnumerator dDown()
    {
        for (int i = 0; i < 17; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Downbar.Translate(0, -4f, 0);
        }
        yield return null;
    }

    IEnumerator dUp()
    {
        for (int i = 0; i < 17; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Downbar.Translate(0, 4f, 0);
        }
        yield return null;
    }

    IEnumerator sDown()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Sidebar.Translate(8f, 0, 0);
        }
        yield return null;
    }

    IEnumerator sUp()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Sidebar.Translate(-8f, 0, 0);
        }
        yield return null;
    }
}
