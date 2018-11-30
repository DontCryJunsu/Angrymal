using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
조건 목록
Always - 항상
HPMoreThanHalf - 체력이 절반 이상일 때

명령어 목록
ChaseClosestEnemy - 가까운 적 추적
*/

public class Command : MonoBehaviour {
    public static string[,] cat = new string[4, 2];
    public static string[,] chicken = new string[4, 2];
    public static string[,] bchicken = new string[4, 2];
    public static string[,] bufalo = new string[4, 2];
    public static string[,] dog = new string[4, 2];
    public static string[,] elephant = new string[4, 2];
    public static string[,] giraffe = new string[4,2];
    public static string[,] kangaroo = new string[4, 2];
    public static string[,] lion = new string[4, 2];
    public static string[,] mouse = new string[4, 2];
    public static string[,] pig = new string[4, 2];
    public static string[,] sheep = new string[4, 2];
    public static string[,] snake = new string[4, 2];
    public static string[,] wolf = new string[4, 2];

    // Use this for initialization

    void Start () {
        chicken[0, 0] = "EnemyInNear";          //테스트 (테스트 후 "HPMoreThanHalf"로 돌려놔야 함)
        // chicken[0,0] = "HPMoreThanHalf";           // 0번은 조건
        chicken[0,1] = "JustWalk";     // 1번은 행동
        chicken[1, 0] = "Always";           // 0번은 조건
        chicken[1, 1] = "ChaseClosestEnemy";     // 1번은 행동
        cat[0, 0] = "Always";        
        cat[0, 1] = "JustWalk";      


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



