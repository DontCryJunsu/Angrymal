using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    Image fadeImg;
    float start = 0f;
    float end = 1f;
    float time = 0f;
    public float aniTime = 2f;

    public void Btn()
    {
        fadeImg = GetComponent<Image>();
        StartCoroutine("PlayFadein");
    }
    IEnumerator PlayFadein()
    {
        Color color = fadeImg.color;
        time = 0f;
        while (color.a < 1f)
        {
            time += Time.deltaTime / aniTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImg.color = color;
            yield return null;
        }
        SceneManager.LoadSceneAsync("LobbyScene");
    }
    public void SC2()
    {
        fadeImg = GetComponent<Image>();
        StopAllCoroutines();
        StartCoroutine("PlayFadein2");
    }
    IEnumerator PlayFadein2()
    {
        Color color = fadeImg.color;
        time = 0f;
        while (color.a < 1f)
        {
            time += Time.deltaTime / aniTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImg.color = color;
            yield return null;
        }
        SceneManager.LoadSceneAsync("Shop");
    }
}
