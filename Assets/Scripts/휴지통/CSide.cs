using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CSide : MonoBehaviour
{
    public GameObject S1;
    public GameObject S2;
    public GameObject S3;

    public GameObject mvPan;
    public GameObject atkPan;

    public Text ST0;
    public Text ST1;
    public Text ST2;

    bool tb = false;

    GameObject curG;
    GameObject Pan;

    public void Side1()  // 사이드 번호 선택
    {
        if (LobbyManager.cNum == 0)
        {
            LobbyManager.cNum = 1;
            curG = S1;
            StartCoroutine("sUp");
        }
    }
    public void Side2()
    {
        if (LobbyManager.cNum == 0)
        {
            LobbyManager.cNum = 2;
            curG = S2;
            StartCoroutine("sUp");
        }
    }
    public void Side3()
    {
        if (LobbyManager.cNum == 0)
        {
            LobbyManager.cNum = 3;
            curG = S3;
            StartCoroutine("sUp");
        }
    }

    public void MVPan()  // 사이드 이동 선택
    {
        if (tb == false)
        {
            Pan = mvPan;
            tb = true;
            mvPan.SetActive(true);
            StartCoroutine("PanUp");
            ST1.text = "선택 : ";
            ST2.text = "선택 : ";
            CmdAdd.A = false;
            CmdAdd.B = false;
        }
    }

    public void ATKPan()  // 사이드 공격 선택
    {
        if (tb == false)
        {
            Pan = atkPan;
            tb = true;
            atkPan.SetActive(true);
            StartCoroutine("PanUp");
            ST0.text = "선택 : ";
            CmdAdd.C = false;
        }
    }

    public void mvComplete()//이동완료버튼
    {
        //PlayerPrefs.GetInt("snake1CMD") = 1이면 이동 2이면 공격
        PlayerPrefs.SetInt(LobbyManager.aniNum+LobbyManager.cNum+"CMD", 1);
        tb = false;
        StartCoroutine("sDown");
        StartCoroutine("PanDown");
        GameObject.Find(LobbyManager.aniNum + LobbyManager.cNum).GetComponent<Text>().text = ST1.text + ST2.text;
    }

    public void atkComplete()//공격완료버튼
    {
        PlayerPrefs.SetInt(LobbyManager.aniNum + LobbyManager.cNum + "CMD", 2);
        tb = false;
        StartCoroutine("sDown");
        StartCoroutine("PanDown");
        GameObject.Find(LobbyManager.aniNum + LobbyManager.cNum).GetComponent<Text>().text = ST0.text;
    }

    IEnumerator PanDown()
    {
        for (int i = 0; i < 16; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Pan.transform.localScale -= new Vector3(0.05f, 0.05f, 0);
        }
        Pan.SetActive(false);
        yield return null;
    }
    IEnumerator PanUp()
    {
        for (int i = 0; i < 16; i++)
        {
            yield return new WaitForSeconds(0.01f);
            Pan.transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }
        yield return null;
    }

    IEnumerator sDown()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            curG.transform.Translate(16f, 0, 0);
        }
        LobbyManager.cNum = 0;
        yield return null;
    }

    IEnumerator sUp()
    {
        for (int i = 0; i < 30; i++)
        {
            yield return new WaitForSeconds(0.01f);
            curG.transform.Translate(-16f, 0, 0);
        }
        yield return null;
    }
}
