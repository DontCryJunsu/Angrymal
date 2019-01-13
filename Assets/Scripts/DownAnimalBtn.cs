using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownAnimalBtn : MonoBehaviour {

    GameObject C1;
    GameObject C2;
    GameObject C3;
    // Use this for initialization
    void Awake()
    {
        if (PlayerPrefs.GetString("C1", "1") != "1") // 무언가 값이 들어가 있다면
        {
            C1 = GameObject.Find(PlayerPrefs.GetString("C1"));
            C1.gameObject.transform.position = new Vector3(520f, 29f, 0f);
        }

        if (PlayerPrefs.GetString("C2", "1") != "1") // 무언가 값이 들어가 있다면
        {
            C2 = GameObject.Find(PlayerPrefs.GetString("C2"));
            C2.gameObject.transform.position = new Vector3(640f, 29f, 0f);
        }
        if (PlayerPrefs.GetString("C3", "1") != "1") // 무언가 값이 들어가 있다면
        {
            C3 = GameObject.Find(PlayerPrefs.GetString("C3"));
            C3.gameObject.transform.position = new Vector3(760f, 29f, 0f);
        }
    }
}
