using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
조건 목록
Always - 항상
HPMoreThanHalf - 체력이 절반 이상일 때
HPLessThanHalf - 체력이 절반 미만일 때
EnemyInNear - 주변에 적이 있을 때 
NoEnemyInNear - 주변에 적이 없을 때 

행동 목록
JustWalk - 무작위 이동
ChaseClosestEnemy - 가까운 적 추적

공격 조건 목록
AlwaysAttack - 항상 공격
HPMoreThanHalfAttack - 자신의 체력이 절반 이상일 때 공격
*/

public class Command : MonoBehaviour {
    public static string[,] cat = new string[4, 3];
    public static string[,] chicken = new string[4, 3];
    public static string[,] bchicken = new string[4, 3];
    public static string[,] bufalo = new string[4, 3];
    public static string[,] dog = new string[4, 3];
    public static string[,] elephant = new string[4, 3];
    public static string[,] giraffe = new string[4,3];
    public static string[,] kangaroo = new string[4, 3];
    public static string[,] lion = new string[4, 3];
    public static string[,] mouse = new string[4, 3];
    public static string[,] pig = new string[4, 3];
    public static string[,] sheep = new string[4, 3];
    public static string[,] snake = new string[4, 3];
    public static string[,] wolf = new string[4, 3];

    // Use this for initialization

    void Start () {
        chicken[0, 0] = "NoEnemyInNear";          // 0번은 조건
        chicken[0,1] = "JustWalk";     // 1번은 행동
        chicken[1, 0] = "Always";               // 0번은 조건
        chicken[1, 1] = "ChaseClosestEnemy";             // 1번은 행동
        chicken[3, 0] = "Always";    // [3,0]과 [3,1]은 고정
        chicken[0, 2] = "HPMoreThanHalfAttack";    // 2번은 공격 조건
        chicken[3, 1] = "JustWalk";
        cat[0, 0] = "Always";        
        cat[0, 1] = "JustWalk";
        cat[3, 0] = "Always";
        cat[3, 1] = "JustWalk";
        chicken[1, 2] = "AlwaysAttack";
        sheep[0, 0] = "EnemyInNear";
        sheep[0, 1] = "ChaseClosestEnemy";
        sheep[1, 0] = "Always";
        sheep[1, 1] = "JustWalk";


    }
	
	// Update is called once per frame
	void Update () {
        
    }

/*
    public void test()
    {
        Debug.Log("test");
    }
    */
}



