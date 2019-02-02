using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
조건 목록 <8개>
Always - 항상
EnemyInNear -    주변에 적이 있을 때 
HPMoreThanHalf - 체력이 절반 이상일 때
HPLessThanHalf - 체력이 절반 미만일 때
NoEnemyInNear - 주변에 적이 없을 때 
OurTileIsMore - 내 땅이 더 많을 때
OurTileIsLess - 내 땅이 더 적을 때
NoEmptyTile - 빈 땅이 없을 때

행동 목록 <5개>
ChaseClosestEnemy - 가까운 적 추적
JustWalk - 무작위 이동
GoToEnemyTile - 적의 땅으로 이동
ChaseClosestAlly - 가까운 아군에게 이동
GoToEmtyTile - 빈 땅으로 이동

공격 조건 목록 <9개>
AlwaysAttack - 항상 공격
MyHPIsMoreAttack - 체력이 더 많을 때 공격
HPMoreThanHalfAttack - 체력이 절반 이상일 때 공격
HPLessThanHalfAttack - 체력이 절반 미만일 때 공격
EnemyHPMoreThanHalfAttack - 상대 체력이 절반 이상일 때 공격
EnemyHPLessThanHalfAttack - 상대 체력이 절반 미만일 때 공격
OurTileIsMoreAttack - 땅이 더 많을 때 공격
OurTileIsLessAttack - 땅이 더 적을 때 공격
NoEmptyTileAttack - 빈 땅이 없을 때 공격
*/

public class Command : MonoBehaviour
{
    public static string[,] cat = new string[1, 3];
    public static string[,] chicken = new string[1, 3];
    public static string[,] bchicken = new string[1, 3];
    public static string[,] buffalo = new string[1, 3];
    public static string[,] dog = new string[1, 3];
    public static string[,] elephant = new string[1, 3];
    public static string[,] jiraffe = new string[1, 3];
    public static string[,] kangaroo = new string[1, 3];
    public static string[,] lion = new string[1, 3];
    public static string[,] mouse = new string[1, 3];
    public static string[,] pig = new string[1, 3];
    public static string[,] sheep = new string[1, 3];
    public static string[,] snake = new string[1, 3];
    public static string[,] wolf = new string[1, 3];
    public static int bluetile = 0;
    public static int redtile = 0;


    //public Text RB;

    //private void Update()
    //{
    //    //RB.text = Command.redtile + "개 / " + Command.bluetile + "개";
    //}
    // Use this for initialization

    void Start()
    {
        /*
        chicken[0, 0] = "NoEnemyInNear";          // 0번은 조건
        chicken[0,1] = "JustWalk";     // 1번은 행동
        chicken[1, 0] = "Always";               // 0번은 조건
        chicken[1, 1] = "ChaseClosestEnemy";             // 1번은 행동
        chicken[3, 0] = "Always";    // [3,0]과 [3,1]은 고정
        */
        //chicken[0, 0] = "Always";
        //chicken[0, 1] = "JustWalk";
        //chicken[1, 0] = "Always";
        //chicken[1, 1] = "JustWalk";
        //chicken[0, 2] = "AlwaysAttack";    // 2번은 공격 조건
        //chicken[3, 1] = "JustWalk";
        //cat[0, 0] = "Always";        
        //cat[0, 1] = "JustWalk";

        //sheep[0, 0] = "NoEmptyTile";
        //sheep[0, 1] = "JustWalk";
        //sheep[1, 0] = "Always";
        //sheep[1, 1] = "GoToEmptyTile";
        //sheep[0, 2] = "HPMoreThanHalfAttack";
        //sheep[1, 2] = "OurTileIsMoreAttack";
        /*<명령어 줄이기>
        cat[1, 0] = "Always";
        cat[1, 1] = "JustWalk";
        dog[1, 0] = "Always";
        dog[1, 1] = "JustWalk";
        wolf[1, 0] = "Always";
        wolf[1, 1] = "JustWalk";
        sheep[1, 0] = "Always";
        sheep[1, 1] = "JustWalk";
        snake[1, 0] = "Always";
        snake[1, 1] = "JustWalk";
        buffalo[1, 0] = "Always";
        buffalo[1, 1] = "JustWalk";
        jiraffe[1, 0] = "Always";
        jiraffe[1, 1] = "JustWalk";
        kangaroo[1, 0] = "Always";
        kangaroo[1, 1] = "JustWalk";
        chicken[1, 0] = "Always";
        chicken[1, 1] = "JustWalk";
        lion[1, 0] = "Always";
        lion[1, 1] = "JustWalk";
        elephant[1, 0] = "Always";
        elephant[1, 1] = "JustWalk";
        pig[1, 0] = "Always";
        pig[1, 1] = "JustWalk";
        mouse[1, 0] = "Always";
        mouse[1, 1] = "JustWalk";
        */

        snakeGo();
        mouseGo();
        catGo();
        dogGo();
        wolfGo();
        sheepGo();
        buffaloGo();
        jiraffeGo();
        kangarooGo();
        chickenGo();
        lionGo();
        elephantGo();
        pigGo();
    }

    //PlayerPrefs.GetInt("snake1CMD") = 1이면 이동 2이면 공격

    public void snakeGo()
    {
        snake[0, 0] = PlayerPrefs.GetString("snake1A");
        snake[0, 1] = PlayerPrefs.GetString("snake1B");
    }

    public void mouseGo()
    {
        mouse[0, 0] = PlayerPrefs.GetString("mouse1A");
        mouse[0, 1] = PlayerPrefs.GetString("mouse1B");
    }

    public void pigGo()
    {
        pig[0, 0] = PlayerPrefs.GetString("pig1A");
        pig[0, 1] = PlayerPrefs.GetString("pig1B");
    }

    public void elephantGo()
    {
        elephant[0, 0] = PlayerPrefs.GetString("elephant1A");
        elephant[0, 1] = PlayerPrefs.GetString("elephant1B");
    }

    public void lionGo()
    {
        lion[0, 0] = PlayerPrefs.GetString("lion1A");
        lion[0, 1] = PlayerPrefs.GetString("lion1B");
    }

    public void chickenGo()
    {

        chicken[0, 0] = PlayerPrefs.GetString("chicken1A");
        chicken[0, 1] = PlayerPrefs.GetString("chicken1B");
    }

    public void kangarooGo()
    {
        kangaroo[0, 0] = PlayerPrefs.GetString("kangaroo1A");
        kangaroo[0, 1] = PlayerPrefs.GetString("kangaroo1B");
    }

    public void jiraffeGo()
    {

        jiraffe[0, 0] = PlayerPrefs.GetString("jiraffe1A");
        jiraffe[0, 1] = PlayerPrefs.GetString("jiraffe1B");
    }
    public void buffaloGo()
    {
        buffalo[0, 0] = PlayerPrefs.GetString("buffalo1A");
        buffalo[0, 1] = PlayerPrefs.GetString("buffalo1B");
    }

    public void sheepGo()
    {
        sheep[0, 0] = PlayerPrefs.GetString("sheep1A");
        sheep[0, 1] = PlayerPrefs.GetString("sheep1B");
    }

    public void wolfGo()
    {
        wolf[0, 0] = PlayerPrefs.GetString("wolf1A");
        wolf[0, 1] = PlayerPrefs.GetString("wolf1B");
    }

    public void dogGo()
    {
        dog[0, 0] = PlayerPrefs.GetString("dog1A");
        dog[0, 1] = PlayerPrefs.GetString("dog1B");
    }

    public void catGo()
    {
        cat[0, 0] = PlayerPrefs.GetString("cat1A");
        cat[0, 1] = PlayerPrefs.GetString("cat1B");
    }
}