using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{

    public GameObject DiaText1;
    public GameObject DiaText2;
    public GameObject DiaText3;
    public GameObject DiaText4;

    public GameObject catPan;

    void Start()
    {
        if (!PlayerPrefs.GetInt("tuto", 0).Equals(5))
        {
            PlayerPrefs.SetInt("tuto", 0);
            catPan.SetActive(true);
            Invoke("TriggerDialogue", 1.2f);
        }
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("tuto", 0).Equals(1))
        {
            PlayerPrefs.SetInt("tuto", 2);
            DiaText1.SetActive(false);
            DiaText2.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tuto", 0).Equals(3))
        {
            PlayerPrefs.SetInt("tuto", 4);
            DiaText2.SetActive(false);
            DiaText3.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("tuto", 0).Equals(4) && LobbyManager.loadAni==3)
        {
            PlayerPrefs.SetInt("tuto", 5);
            DiaText3.SetActive(false);
            DiaText4.SetActive(true);
        }
        //Debug.Log(LobbyManager.loadAni);
    }

    public void TriggerDialogue()
    {
        DiaText1.SetActive(true);
    }
}