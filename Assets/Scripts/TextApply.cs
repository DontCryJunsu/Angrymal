using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextApply : MonoBehaviour {

    public GameObject X;

    public Text Stext0;
    public Text Stext1;
    public Text Stext2;

    void Update()
    {
        if(Stext0.text.Equals("명령어를 선택 해주세요.") && Stext1.text.Equals("명령어를 선택 해주세요.") && Stext2.text.Equals("명령어를 선택 해주세요."))
        {
            X.SetActive(true);
        }
        else
        {
            X.SetActive(false);
        }
    }
}
