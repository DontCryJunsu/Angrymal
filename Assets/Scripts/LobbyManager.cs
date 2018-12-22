using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{   
    //1.고양이 2.병아리 3.물소 4.닭 5.개 6.코끼리 7.기린 8.캥거루 9.사자 10.쥐 11.돼지 12.양 13.뱀 14.늑대
    public static string aniNum = null;
    public static int cNum = 0;
    public static bool esc = false;
    public static int loadAni = 0;
    public GameObject ship;

    public GameObject fade;
    Image fadeImg;
    float start = 0f;
    float end = 1f;
    float time = 0f;
    public float aniTime = 2f;

    public void ESC()
    {
        esc = true;
    }
    
    public void StartBtn()
    {
        fadeImg = fade.GetComponent<Image>();
        fade.SetActive(true);
        ship.GetComponent<Animator>().enabled = true;
        StartCoroutine("PlayFadeOut");
    }

    IEnumerator PlayFadeOut()
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
    }


    //public void Update()
    //{
    //    //Debug.Log("선택된 동물의 이름은 " + aniNum + " / 선택된 명령은 " + cNum);
    //}
}
