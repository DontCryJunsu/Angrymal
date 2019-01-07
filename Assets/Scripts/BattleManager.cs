using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    GameObject ship;
    int baseNum;

    //public GameObject fade;
    //Image fadeImg;
    //float start = 1f;
    //float end = 0f;
    //float time = 0f;
    //public float aniTime = 2f;

    Vector3 vec;
    Quaternion qua;

    public static bool ST;
    public GameObject Angrymal;

    void Awake()
    {
        ST = false;
        PhotonNetwork.isMessageQueueRunning = true;
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            baseNum = Random.Range(1, 4);
            Debug.Log(baseNum);
        }
        else if (PlayerPrefs.GetString("Team").Equals("B"))
        {
            baseNum = Random.Range(4, 7);
            Debug.Log(baseNum);
        }
        CreatePlayer();
    }

    //void Start()
    //{
    //    fadeImg = fade.GetComponent<Image>();
    //    StartCoroutine("PlayFadein");
    //}

    void CreatePlayer()
    {
        if (baseNum == 1)
        {
            vec = new Vector3(1.8f, -7f, 16.75f);
            qua = Quaternion.Euler(0f, 30f, 0f);
            ship = PhotonNetwork.Instantiate("ship", new Vector3(-0.41f, -2.25f, 12.9f), Quaternion.Euler(0f, 26.1f, 0f), 0);
            StartCoroutine("shipDown");
        }
        else if (baseNum == 2)
        {
            vec = new Vector3(3.7f, -7f, 55.12f);
            qua = Quaternion.Euler(0f, 140f, 0f);
            ship = PhotonNetwork.Instantiate("ship", new Vector3(5.6f, -2.25f, 59.77f), Quaternion.Euler(0f, 170.4f, 0f), 0);
            StartCoroutine("shipDown");
        }
        else if (baseNum == 3)
        {
            vec = new Vector3(48.16f, -7f, 28.23f);
            qua = Quaternion.Euler(0f, 300f, 0f);
            ship = PhotonNetwork.Instantiate("ship", new Vector3(51.9f, -2.25f, 27.75f), Quaternion.Euler(0f, -61.1f, 0f), 0);
            StartCoroutine("shipDown");
        }
        else if (baseNum == 4)
        {
            vec = new Vector3(-3.6f, -7f, 39.54f);
            qua = Quaternion.Euler(0f, 90f, 0f);
            ship = PhotonNetwork.Instantiate("ship", new Vector3(-8.7f, -2.25f, 42.12f), Quaternion.Euler(0f, -90.4f, 0f), 0);
            StartCoroutine("shipDown");
        }
        else if (baseNum == 5)
        {
            vec = new Vector3(37.4f, -7f, 55.9f);
            qua = Quaternion.Euler(0f, 260f, 0f);
            ship = PhotonNetwork.Instantiate("ship", new Vector3(42.2f, -2.25f, 54.9f), Quaternion.Euler(0f, 90.3f, 0f), 0);
            StartCoroutine("shipDown");
        }
        else if (baseNum == 6)
        {
            vec = new Vector3(33.3f, -7f, 12.1f);
            qua = Quaternion.Euler(0f, 320f, 0f);
            ship = PhotonNetwork.Instantiate("ship", new Vector3(33.42f, -2.25f, 5.15f), Quaternion.Euler(0f, 132.3f, 0f), 0);
            StartCoroutine("shipDown");
        }
    }
    void Update()
    {
        if(ST)
        {
            Angrymal.SetActive(true);
        }
    }

    IEnumerator shipDown()
    {
        for (int i = 0; i < 60; i++)
        {
            yield return new WaitForSeconds(0.03f);
            ship.transform.Translate(0, -0.1f, 0);
        }
        yield return null;
    }

    //IEnumerator PlayFadein()
    //{
    //    Color color = fadeImg.color;
    //    time = 0f;
    //    while (color.a > 0f)
    //    {
    //        time += Time.deltaTime / aniTime;
    //        color.a = Mathf.Lerp(start, end, time);
    //        fadeImg.color = color;
    //        yield return null;
    //    }
    //    fade.SetActive(false);
    //}

    public void chicken()
    {
        if(PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RChicken", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BChicken", vec, qua, 0);
        }
    }
    public void dog()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RDog", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BDog", vec, qua, 0);
        }
    }
    public void cat()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RCat", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BCat", vec, qua, 0);
        }
    }
    public void sheep()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RSheep", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BSheep", vec, qua, 0);
        }
    }
    public void mouse()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RMouse", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BMouse", vec, qua, 0);
        }
    }
    public void lion()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RLion", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BLion", vec, qua, 0);
        }
    }
    public void buffalo()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RBuffalo", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BBuffalo", vec, qua, 0);
        }
    }
    public void jiraffe()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RJiraffe", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BJiraffe", vec, qua, 0);
        }
    }
    public void elephant()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RElephant", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BElephant", vec, qua, 0);
        }
    }
    public void wolf()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RWolf", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BWolf", vec, qua, 0);
        }
    }
    public void pig()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RPig", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BPig", vec, qua, 0);
        }
    }
    public void snake()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RSnake", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BSnake", vec, qua, 0);
        }
    }
    public void kangaroo()
    {
        if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            PhotonNetwork.Instantiate("RKangaroo", vec, qua, 0);
        }
        else
        {
            PhotonNetwork.Instantiate("BKangaroo", vec, qua, 0);
        }
    }
    public void Die(GameObject iskilled)
    {
        PhotonNetwork.Destroy(iskilled.gameObject);
    }
}

