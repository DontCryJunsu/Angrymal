using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMgr : MonoBehaviour
{
    public float aniTime = 2f;
    float start = 0f;
    float end = 1f;
    float time = 0f;

    public GameObject nPanel;
    public GameObject rePanel;
    public InputField inputName;
    public GameObject fade;
    Image fadeImg;
    string userName;
    bool isPlaying = false;

    void Awake()
    {
        fadeImg = fade.GetComponent<Image>();
        userName = PlayerPrefs.GetString("userName");
        if (string.IsNullOrEmpty(userName))
        {
            nPanel.SetActive(true);
        }
        else
        {
            LobbyScene();
            Debug.Log(userName + "님 환영합니다.");
        }
    }
    public void confirmBtn()
    {
        if (inputName.text != null)
        {
            rePanel.SetActive(true);
        }
    }
    public void confirmName()
    {
        PlayerPrefs.SetString("userName", inputName.text);
        LobbyScene();
    }
    public void cancle()
    {
        rePanel.SetActive(false);
    }
    
    void LobbyScene()
    {
        rePanel.SetActive(false);
        nPanel.SetActive(false);

        StartCoroutine("PlayFadeOut");
    }
    IEnumerator PlayFadeOut()
    {
        isPlaying = true;
        Color color = fadeImg.color;
        time = 0f;
        while(color.a < 1f)
        {
            time += Time.deltaTime / aniTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImg.color = color;
            yield return null;
        }
        isPlaying = false;
        SceneManager.LoadSceneAsync("LobbyScene");
    }
}
