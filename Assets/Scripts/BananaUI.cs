using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaUI : MonoBehaviour
{
    public Text Bana;
    void Start()
    {
        Bana.text = PlayerPrefs.GetInt("Money", 10000).ToString();
    }
}
