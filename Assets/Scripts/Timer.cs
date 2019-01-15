using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text _text;
    float timer = 30;
    int min = 2;
    public GameObject upPan;
    public GameObject downPan;
    bool swit = false;
    void Update()
    {
        if(!swit)
            timer -= Time.deltaTime;
        if (min > 0 && timer < 0)
        {
            min--;
            timer = 60;
        }

        _text.text = string.Format("{0:D2} : {1:D2}", min, (int)timer);

        if (min == 0 && timer < 0 && !swit)
        {
            timer = 0;
            StartCoroutine(End());
        }
        if (PlayerPrefs.GetInt("isVictory", 0).Equals(1))
        {
            PlayerPrefs.SetInt("isVictory", 0);
            StartCoroutine(End2());
        }
    }
    IEnumerator End()
    {
        swit = true;
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            upPan.transform.Translate(-29.3f, 0, 0);
            downPan.transform.Translate(29.3f, 0, 0);
        }
        if (PlayerPrefs.GetString("Team").Equals("B"))
        {
            if (Command.bluetile > Command.redtile)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                //패배

                SceneManager.LoadScene("Lose");
            }
        }
        else if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            if (Command.bluetile <= Command.redtile)
            {
                //승리

                SceneManager.LoadScene("Win");
            }
            else
            {
                //패배

                SceneManager.LoadScene("Lose");
            }
        }
        yield return null;
    }
    IEnumerator End2()
    {
        swit = true;
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.01f);
            upPan.transform.Translate(-29.3f, 0, 0);
            downPan.transform.Translate(29.3f, 0, 0);
        }
        SceneManager.LoadScene("Win");

        yield return null;
    }
}
