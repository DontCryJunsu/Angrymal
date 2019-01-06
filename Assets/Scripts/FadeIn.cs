using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    Image fadeImg;
    float start = 1f;
    float end = 0f;
    float time = 0f;
    public float aniTime = 2f;

    // Use this for initialization
    void Start () {
        fadeImg = GetComponent<Image>();
        StartCoroutine("PlayFadein");
    }
    IEnumerator PlayFadein()
    {
        Color color = fadeImg.color;
        time = 0f;
        while (color.a > 0f)
        {
            time += Time.deltaTime / aniTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImg.color = color;
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
