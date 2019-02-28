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
    int money;
    public Animator ani;
    void FixedUpdate()
    {
        if (!swit)
            timer -= Time.deltaTime;
        if (min > 0 && timer < 0)
        {
            min--;
            timer = 60;
        }

        _text.text = string.Format("{0:D2} : {1:D2}", min, (int)timer);

        if (min == 0 && timer < 0 && !swit)
        {
            swit = true;
            timer = 0;
            ani.enabled = true;
            Invoke("End", 2f);
            End();
        }
        if (PlayerPrefs.GetInt("isVictory", 0).Equals(1) && PlayerPrefs.GetInt("isLose").Equals(0))
        {
            PlayerPrefs.SetInt("isVictory", 0);
            ani.enabled = true;
            Invoke("End2", 2f);
        }
    }
    void End()
    {
        if (PlayerPrefs.GetString("Team").Equals("B"))
        {
            if (Command.bluetile > Command.redtile)
            {
                money = PlayerPrefs.GetInt("Money", 0);
                money += 20;
                PlayerPrefs.SetInt("Money", money);
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("Win");
            }
            else
            {
                money = PlayerPrefs.GetInt("Money", 0);
                money += 10;
                PlayerPrefs.SetInt("Money", money);
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("Lose");
            }
        }
        else if (PlayerPrefs.GetString("Team").Equals("R"))
        {
            if (Command.bluetile <= Command.redtile)
            {
                money = PlayerPrefs.GetInt("Money", 0);
                money += 20;
                PlayerPrefs.SetInt("Money", money);
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("Win");
            }
            else
            {
                money = PlayerPrefs.GetInt("Money", 0);
                money += 10;
                PlayerPrefs.SetInt("Money", money);
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene("Lose");
            }
        }
    }
    void End2()
    {
        money = PlayerPrefs.GetInt("Money", 0);
        money += 20;
        PlayerPrefs.SetInt("Money", money);
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("Win");
    }
}
