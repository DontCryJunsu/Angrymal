using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text _text;
    float timer = 30;
    int min = 2;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            min--;
            timer = 60;
        }

        _text.text = string.Format("{0:D2} : {1:D2}", min, (int)timer);
    }
}
