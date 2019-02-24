using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public Text Name;
    void Start()
    {
        Name.text = PlayerPrefs.GetString("userName","사용자") + " <color=black>부족</color>";
    }
}
