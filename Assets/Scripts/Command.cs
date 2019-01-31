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

public class Command : MonoBehaviour {
    public static string[,] cat = new string[2, 3];
    public static string[,] chicken = new string[2, 3];
    public static string[,] bchicken = new string[2, 3];
    public static string[,] buffalo = new string[2, 3];
    public static string[,] dog = new string[2, 3];
    public static string[,] elephant = new string[2, 3];
    public static string[,] jiraffe = new string[2, 3];
    public static string[,] kangaroo = new string[2, 3];
    public static string[,] lion = new string[2, 3];
    public static string[,] mouse = new string[2, 3];
    public static string[,] pig = new string[2, 3];
    public static string[,] sheep = new string[2, 3];
    public static string[,] snake = new string[2, 3];
    public static string[,] wolf = new string[2, 3];
    public static int bluetile = 0;
    public static int redtile = 0;


    //public Text RB;

    //private void Update()
    //{
    //    //RB.text = Command.redtile + "개 / " + Command.bluetile + "개";
    //}
    // Use this for initialization

    void Start () {
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
        if (PlayerPrefs.GetInt("snake1CMD").Equals(1))
        {
            snake[0, 0] = PlayerPrefs.GetString("snake1A");
            snake[0, 1] = PlayerPrefs.GetString("snake1B");
            snake[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("snake1CMD").Equals(2))
        {
            snake[0, 0] = null;
            snake[0, 1] = null;
            snake[0, 2] = PlayerPrefs.GetString("snake1C");
        }

       
    }

    public void mouseGo()
    {
        if (PlayerPrefs.GetInt("mouse1CMD").Equals(1))
        {
            mouse[0, 0] = PlayerPrefs.GetString("mouse1A");
            mouse[0, 1] = PlayerPrefs.GetString("mouse1B");
            mouse[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("mouse1CMD").Equals(2))
        {
            mouse[0, 0] = null;
            mouse[0, 1] = null;
            mouse[0, 2] = PlayerPrefs.GetString("mouse1C");
        }

  
    }

    public void pigGo()
    {
        if (PlayerPrefs.GetInt("pig1CMD").Equals(1))
        {
            pig[0, 0] = PlayerPrefs.GetString("pig1A");
            pig[0, 1] = PlayerPrefs.GetString("pig1B");
            pig[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("pig1CMD").Equals(2))
        {
            pig[0, 0] = null;
            pig[0, 1] = null;
            pig[0, 2] = PlayerPrefs.GetString("pig1C");
        }


    }

    public void elephantGo()
    {
        if (PlayerPrefs.GetInt("elephant1CMD").Equals(1))
        {
            elephant[0, 0] = PlayerPrefs.GetString("elephant1A");
            elephant[0, 1] = PlayerPrefs.GetString("elephant1B");
            elephant[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("elephant1CMD").Equals(2))
        {
            elephant[0, 0] = null;
            elephant[0, 1] = null;
            elephant[0, 2] = PlayerPrefs.GetString("elephant1C");
        }

 
    }

    public void lionGo()
    {
        if (PlayerPrefs.GetInt("lion1CMD").Equals(1))
        {
            lion[0, 0] = PlayerPrefs.GetString("lion1A");
            lion[0, 1] = PlayerPrefs.GetString("lion1B");
            lion[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("lion1CMD").Equals(2))
        {
            lion[0, 0] = null;
            lion[0, 1] = null;
            lion[0, 2] = PlayerPrefs.GetString("lion1C");
        }

 
    }

    public void chickenGo()
    {
        if (PlayerPrefs.GetInt("chicken1CMD").Equals(1))
        {
            chicken[0, 0] = PlayerPrefs.GetString("chicken1A");
            chicken[0, 1] = PlayerPrefs.GetString("chicken1B");
            chicken[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("chicken1CMD").Equals(2))
        {
            chicken[0, 0] = null;
            chicken[0, 1] = null;
            chicken[0, 2] = PlayerPrefs.GetString("chicken1C");
        }


    }

    public void kangarooGo()
    {
        if (PlayerPrefs.GetInt("kangaroo1CMD").Equals(1))
        {
            kangaroo[0, 0] = PlayerPrefs.GetString("kangaroo1A");
            kangaroo[0, 1] = PlayerPrefs.GetString("kangaroo1B");
            kangaroo[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("kangaroo1CMD").Equals(2))
        {
            kangaroo[0, 0] = null;
            kangaroo[0, 1] = null;
            kangaroo[0, 2] = PlayerPrefs.GetString("kangaroo1C");
        }


    }

    public void jiraffeGo()
    {
        if (PlayerPrefs.GetInt("jiraffe1CMD").Equals(1))
        {
            jiraffe[0, 0] = PlayerPrefs.GetString("jiraffe1A");
            jiraffe[0, 1] = PlayerPrefs.GetString("jiraffe1B");
            jiraffe[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("jiraffe1CMD").Equals(2))
        {
            jiraffe[0, 0] = null;
            jiraffe[0, 1] = null;
            jiraffe[0, 2] = PlayerPrefs.GetString("jiraffe1C");
        }

    
    }

    public void buffaloGo()
    {
        if (PlayerPrefs.GetInt("buffalo1CMD").Equals(1))
        {
            buffalo[0, 0] = PlayerPrefs.GetString("buffalo1A");
            buffalo[0, 1] = PlayerPrefs.GetString("buffalo1B");
            buffalo[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("buffalo1CMD").Equals(2))
        {
            buffalo[0, 0] = null;
            buffalo[0, 1] = null;
            buffalo[0, 2] = PlayerPrefs.GetString("buffalo1C");
        }

  
    }

    public void sheepGo()
    {
        if (PlayerPrefs.GetInt("sheep1CMD").Equals(1))
        {
            sheep[0, 0] = PlayerPrefs.GetString("sheep1A");
            sheep[0, 1] = PlayerPrefs.GetString("sheep1B");
            sheep[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("sheep1CMD").Equals(2))
        {
            sheep[0, 0] = null;
            sheep[0, 1] = null;
            sheep[0, 2] = PlayerPrefs.GetString("sheep1C");
        }

 
    }

    public void wolfGo()
    {
        if (PlayerPrefs.GetInt("wolf1CMD").Equals(1))
        {
            wolf[0, 0] = PlayerPrefs.GetString("wolf1A");
            wolf[0, 1] = PlayerPrefs.GetString("wolf1B");
            wolf[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("wolf1CMD").Equals(2))
        {
            wolf[0, 0] = null;
            wolf[0, 1] = null;
            wolf[0, 2] = PlayerPrefs.GetString("wolf1C");
        }

      
    }

    public void dogGo()
    {
        if (PlayerPrefs.GetInt("dog1CMD").Equals(1))
        {
            dog[0, 0] = PlayerPrefs.GetString("dog1A");
            dog[0, 1] = PlayerPrefs.GetString("dog1B");
            dog[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("dog1CMD").Equals(2))
        {
            dog[0, 0] = null;
            dog[0, 1] = null;
            dog[0, 2] = PlayerPrefs.GetString("dog1C");
        }

    
    }

    public void catGo()
    {
        if (PlayerPrefs.GetInt("cat1CMD").Equals(1))
        {
            cat[0, 0] = PlayerPrefs.GetString("cat1A");
            cat[0, 1] = PlayerPrefs.GetString("cat1B");
            cat[0, 2] = null;
        }
        else if (PlayerPrefs.GetInt("cat1CMD").Equals(2))
        {
            cat[0, 0] = null;
            cat[0, 1] = null;
            cat[0, 2] = PlayerPrefs.GetString("cat1C");
        }

      
    }
}



