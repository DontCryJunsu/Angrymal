using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CmdAdd : MonoBehaviour
{
    public Text Stext0;
    public Text Stext1;
    public Text Stext2;
    public GameObject X1;
    public GameObject X2;

    public static bool A = false;
    public static bool C = false;
    public static bool B = false;

    // ex) snake1A
    public void Cn1()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum+"A", "Always");
        Stext1.text = " 항상";
        A = true;
    }
    public void Cn2()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "EnemyInNear");
        Stext1.text = " 주변에 적이 있을 때";
        A = true;
    }
    public void Cn3()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "HPMoreThanHalf");
        Stext1.text = " 체력이 절반 이상일 때";
        A = true;
    }
    public void Cn4()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "HPLessThanHalf");
        Stext1.text = " 체력이 절반 미만일 때";
        A = true;
    }
    public void Cn5()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "NoEnemyInNear");
        Stext1.text = " 주변에 적이 없을 때";
        A = true;
    }
    public void Cn6()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "OurTileIsMore");
        Stext1.text = " 땅이 더 많을 때";
        A = true;
    }
    public void Cn7()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "OurTileIsLess");
        Stext1.text = " 땅이 더 적을 때";
        A = true;
    }
    public void Cn8()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "NoEmptyTile");
        Stext1.text = " 빈 땅이 없을 때";
        A = true;
    }


    public void Mv1()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "B", "ChaseClosestEnemy");
        Stext2.text = " 가까운 적 추적";
        B = true;
    }
    public void Mv2()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "B", "JustWalk");
        Stext2.text = " 무작위 이동";
        B = true;
    }
    public void Mv3()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "B", "GoToEnemyTile");
        Stext2.text = " 적의 땅으로 이동";
        B = true;
    }
    public void Mv4()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "B", "ChaseClosestAlly");
        Stext2.text = " 가까운 아군에게 이동";
        B = true;
    }
    public void Mv5()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "B", "GoToEmtyTile");
        Stext2.text = " 빈 땅으로 이동";
        B = true;
    }


    public void Ak1()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "AlwaysAttack");
        Stext0.text = " 항상 공격";
        C = true;
    }
    public void Ak2()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "MyHPIsMoreAttack");
        Stext0.text = " 체력이 더 많을 때 공격";
        C = true;
    }
    public void Ak3()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "HPMoreThanHalfAttack");
        Stext0.text = " 체력이 절반 이상일 때 공격";
        C = true;
    }
    public void Ak4()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "HPLessThanHalfAttack");
        Stext0.text = " 체력이 절반 미만일 때 공격";
        C = true;
    }
    public void Ak5()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "EnemyHPMoreThanHalfAttack");
        Stext0.text = " 상대 체력이 절반 이상일 때 공격";
        C = true;
    }
    public void Ak6()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "EnemyHPLessThanHalfAttack");
        Stext0.text = " 상대 체력이 절반 미만일 때 공격";
        C = true;
    }
    public void Ak7()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "OurTileIsMoreAttack");
        Stext0.text = " 땅이 더 많을 때 공격";
        C = true;
    }
    public void Ak8()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "OurTileIsLessAttack");
        Stext0.text = " 땅이 더 적을 때 공격";
        C = true;
    }
    public void Ak9()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "NoEmptyTileAttack");
        Stext0.text = " 빈 땅이 없을 때 공격";
        C = true;
    }
    void Update()
    {
        if(A==true && B==true)
        {
            X1.SetActive(false);
        }
        else
        {
            X1.SetActive(true);
        }

        if(C==true)
        {
            X2.SetActive(false);
        }
        else
        {
            X2.SetActive(true);
        }
    }
}
