using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryUp : MonoBehaviour
{
    public float aniTime = 2f;
    float start = 0f;
    float end = 1f;
    float time = 0f;

    public GameObject fade;
    Image fadeImg;

    void Start()
    {
        fadeImg = fade.GetComponent<Image>();
        StartCoroutine("Up");
    }

    IEnumerator Up()
    {
        for (int i = 0; i < 700; i++)
        {
            yield return new WaitForSeconds(0.015f);
            transform.Translate(new Vector3(0, 1.5f, 0));  //이동
        }
        yield return null;
        StartCoroutine("PlayFadeOut");
    }
    
    IEnumerator PlayFadeOut()
    {
        fade.SetActive(true);
        Color color = fadeImg.color;
        time = 0f;
        while (color.a < 1f)
        {
            time += Time.deltaTime / aniTime;
            color.a = Mathf.Lerp(start, end, time);
            fadeImg.color = color;
            yield return null;
        }
        SceneManager.LoadSceneAsync("StartScene");
    }
    public void startScene()
    {
        fadeImg.raycastTarget = true;
        StartCoroutine(PlayFadeOut());
    }
}
