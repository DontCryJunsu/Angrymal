using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionAdd : MonoBehaviour
{
    public Text ConText;
    public Text ActText;
    public Button GO;
    void Start()
    {
        ConText.text = PlayerPrefs.GetString(transform.name + "2A", "조 건");
        ActText.text = PlayerPrefs.GetString(transform.name + "2B", "행 동");
        check();
    }

    void check()
    {
        if (ConText.text.Equals("조 건") || ActText.text.Equals("행 동"))
            GO.interactable = false;
        else
            GO.interactable = true;
    }

    public void Cn1()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "Always");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "항상");
        ConText.text = "항상";
        check();
    }
    public void Cn2()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "EnemyInNear");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "주변에 적이 있을 때");
        ConText.text = "주변에 적이 있을 때";
        check();
    }
    public void Cn3()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "HPMoreThanHalf");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "체력이 절반 이상일 때");
        ConText.text = "체력이 절반 이상일 때";
        check();
    }
    public void Cn4()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "HPLessThanHalf");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "체력이 절반 미만일 때");
        ConText.text = "체력이 절반 미만일 때";
        check();
    }
    public void Cn5()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "NoEnemyInNear");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "주변에 적이 없을 때");
        ConText.text = "주변에 적이 없을 때";
        check();
    }
    public void Cn6()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "OurTileIsMore");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "땅이 더 많을 때");
        ConText.text = "땅이 더 많을 때";
        check();
    }
    public void Cn7()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "OurTileIsLess");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "땅이 더 적을 때");
        ConText.text = "땅이 더 적을 때";
        check();
    }
    public void Cn8()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + "1A", "NoEmptyTile");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2A", "빈 땅이 없을 때");
        ConText.text = "빈 땅이 없을 때";
        check();
    }


    public void Mv1()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum +"1B", "ChaseClosestEnemy");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2B", "가까운 적 추적");
        ActText.text = " 가까운 적 추적";
        check();
    }
    public void Mv2()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum +"1B", "JustWalk");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2B", " 무작위 이동");
        ActText.text = " 무작위 이동";
        check();
    }
    public void Mv3()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum +"1B", "GoToEnemyTile");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2B", " 적의 땅으로 이동");
        ActText.text = " 적의 땅으로 이동";
        check();
    }
    public void Mv4()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum +"1B", "ChaseClosestAlly");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2B", " 가까운 아군에게 이동");
        ActText.text = " 가까운 아군에게 이동";
        check();
    }
    public void Mv5()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum +"1B", "GoToEmtyTile");
        PlayerPrefs.SetString(LobbyManager.aniNum + "2B", " 빈 땅으로 이동");
        ActText.text = " 빈 땅으로 이동";
        check();
    }
}
