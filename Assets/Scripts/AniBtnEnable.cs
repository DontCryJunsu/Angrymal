using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AniBtnEnable : MonoBehaviour
{
    public GameObject[] Ani;
    public Text Bana;

    void Start()
    {
        shopActive();
    }

    public void shopActive()
    {
        if (PlayerPrefs.GetInt("pigBtn").Equals(1))
        {
            Ani[0].SetActive(false);
        }
        if (PlayerPrefs.GetInt("mouseBtn").Equals(1))
        {
            Ani[1].SetActive(false);
        }
        if (PlayerPrefs.GetInt("sheepBtn").Equals(1))
        {
            Ani[2].SetActive(false);
        }
        if (PlayerPrefs.GetInt("snakeBtn").Equals(1))
        {
            Ani[3].SetActive(false);
        }
        if (PlayerPrefs.GetInt("wolfBtn").Equals(1))
        {
            Ani[4].SetActive(false);
        }
        if (PlayerPrefs.GetInt("kangarooBtn").Equals(1))
        {
            Ani[5].SetActive(false);
        }
        if (PlayerPrefs.GetInt("jiraffeBtn").Equals(1))
        {
            Ani[6].SetActive(false);
        }
        if (PlayerPrefs.GetInt("buffaloBtn").Equals(1))
        {
            Ani[7].SetActive(false);
        }
        if (PlayerPrefs.GetInt("lionBtn").Equals(1))
        {
            Ani[8].SetActive(false);
        }
        if (PlayerPrefs.GetInt("elephantBtn").Equals(1))
        {
            Ani[9].SetActive(false);
        }
        Bana.text = PlayerPrefs.GetInt("Money", 10000).ToString();
    }
}