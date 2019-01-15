using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextMgr : MonoBehaviour
{
    //PlayerPrefs.GetInt("snake1CMD") = 1이면 이동 2이면 공격
    //명령어 PlayerPrefs.GetInt("snake1A")랑 PlayerPrefs.GetInt("snake1B")
    //PlayerPrefs.GetInt("snake1C")
    public Text txt;

    void Start()
    {
        if (PlayerPrefs.GetInt(transform.name + "CMD").Equals(1))
        {
            string A = PlayerPrefs.GetString(transform.name + "A", null);
            string B = PlayerPrefs.GetString(transform.name + "B", null);

            if (A.Equals("Always"))
            {
                A = "항상 ";
            }
            else if (A.Equals("EnemyInNear"))
            {
                A = "주변에 적이 있을 때 ";
            }
            else if (A.Equals("HPMoreThanHalf"))
            {
                A = "체력이 절반 이상일 때 ";
            }
            else if (A.Equals("HPLessThanHalf"))
            {
                A = "체력이 절반 미만일 때 ";
            }
            else if (A.Equals("NoEnemyInNear"))
            {
                A = "주변에 적이 없을 때 ";
            }
            else if (A.Equals("OurTileIsMore"))
            {
                A = "내 땅이 더 많을 때 ";
            }
            else if (A.Equals("OurTileIsLess"))
            {
                A = "내 땅이 더 적을 때 ";
            }
            else if (A.Equals("NoEmptyTile"))
            {
                A = "빈 땅이 없을 때 ";
            }

            if (B.Equals("ChaseClosestEnemy"))
            {
                B = "가까운 적 추적";
            }
            else if (B.Equals("JustWalk"))
            {
                B = "무작위 이동";
            }
            else if (B.Equals("GoToEnemyTile"))
            {
                B = "적의 땅으로 이동";
            }
            else if (B.Equals("ChaseClosestAlly"))
            {
                B = "가까운 아군에게 이동";
            }
            else if (B.Equals("GoToEmtyTile"))
            {
                B = "빈 땅으로 이동";
            }
            else if (A.Equals("0"))
            {
                A = "명령어를 선택 해주세요.";
            }
            txt.text = A + B;
        }
        else if (PlayerPrefs.GetInt(transform.name + "CMD").Equals(2))
        {
            string C = PlayerPrefs.GetString(transform.name + "C", null);
            if (C.Equals("AlwaysAttack"))
            {
                C = "항상 공격";
            }
            else if (C.Equals("MyHPIsMoreAttack"))
            {
                C = "체력이 더 많을 때 공격";
            }
            else if (C.Equals("HPMoreThanHalfAttack"))
            {
                C = "체력이 절반 이상일 때 공격";
            }
            else if (C.Equals("HPLessThanHalfAttack"))
            {
                C = "체력이 절반 미만일 때 공격";
            }
            else if (C.Equals("EnemyHPMoreThanHalfAttack"))
            {
                C = "상대 체력이 절반 이상일 때 공격";
            }
            else if (C.Equals("EnemyHPLessThanHalfAttack"))
            {
                C = "상대 체력이 절반 미만일 때 공격";
            }
            else if (C.Equals("OurTileIsMoreAttack"))
            {
                C = "땅이 더 많을 때 공격";
            }
            else if (C.Equals("OurTileIsLessAttack"))
            {
                C = "땅이 더 적을 때 공격";
            }
            else if (C.Equals("NoEmptyTileAttack"))
            {
                C = "빈 땅이 없을 때 공격";
            }
            else if(C.Equals("0"))
            {
                C = "명령어를 선택 해주세요.";
            }
            txt.text = C;
        }
        else
        {
            txt.text = "명령어를 선택 해주세요.";
        }
    }
    public void SelectCmd()
    {
        txt.text = "명령어를 선택 해주세요.";
    }
}
