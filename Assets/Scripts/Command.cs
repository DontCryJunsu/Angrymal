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
    public static string[,] cat = new string[4, 3];
    public static string[,] chicken = new string[4, 3];
    public static string[,] bchicken = new string[4, 3];
    public static string[,] buffalo = new string[4, 3];
    public static string[,] dog = new string[4, 3];
    public static string[,] elephant = new string[4, 3];
    public static string[,] jiraffe = new string[4,3];
    public static string[,] kangaroo = new string[4, 3];
    public static string[,] lion = new string[4, 3];
    public static string[,] mouse = new string[4, 3];
    public static string[,] pig = new string[4, 3];
    public static string[,] sheep = new string[4, 3];
    public static string[,] snake = new string[4, 3];
    public static string[,] wolf = new string[4, 3];
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

        cat[3, 0] = "Always";
        cat[3, 1] = "JustWalk";
        dog[3, 0] = "Always";
        dog[3, 1] = "JustWalk";
        wolf[3, 0] = "Always";
        wolf[3, 1] = "JustWalk";
        sheep[3, 0] = "Always";
        sheep[3, 1] = "JustWalk";
        snake[3, 0] = "Always";
        snake[3, 1] = "JustWalk";
        buffalo[3, 0] = "Always";
        buffalo[3, 1] = "JustWalk";
        jiraffe[3, 0] = "Always";
        jiraffe[3, 1] = "JustWalk";
        kangaroo[3, 0] = "Always";
        kangaroo[3, 1] = "JustWalk";
        chicken[3, 0] = "Always";
        chicken[3, 1] = "JustWalk";
        lion[3, 0] = "Always";
        lion[3, 1] = "JustWalk";
        elephant[3, 0] = "Always";
        elephant[3, 1] = "JustWalk";
        pig[3, 0] = "Always";
        pig[3, 1] = "JustWalk";
        mouse[3, 0] = "Always";
        mouse[3, 1] = "JustWalk";

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

        if (PlayerPrefs.GetInt("snake2CMD").Equals(1))
        {
            snake[1, 0] = PlayerPrefs.GetString("snake2A");
            snake[1, 1] = PlayerPrefs.GetString("snake2B");
            snake[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("snake2CMD").Equals(2))
        {
            snake[1, 0] = null;
            snake[1, 1] = null;
            snake[1, 2] = PlayerPrefs.GetString("snake2C");
        }

        if (PlayerPrefs.GetInt("snake3CMD").Equals(1))
        {
            snake[2, 0] = PlayerPrefs.GetString("snake3A");
            snake[2, 1] = PlayerPrefs.GetString("snake3B");
            snake[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("snake3CMD").Equals(2))
        {
            snake[2, 0] = null;
            snake[2, 1] = null;
            snake[2, 2] = PlayerPrefs.GetString("snake3C");
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

        if (PlayerPrefs.GetInt("mouse2CMD").Equals(1))
        {
            mouse[1, 0] = PlayerPrefs.GetString("mouse2A");
            mouse[1, 1] = PlayerPrefs.GetString("mouse2B");
            mouse[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("mouse2CMD").Equals(2))
        {
            mouse[1, 0] = null;
            mouse[1, 1] = null;
            mouse[1, 2] = PlayerPrefs.GetString("mouse2C");
        }

        if (PlayerPrefs.GetInt("mouse3CMD").Equals(1))
        {
            mouse[2, 0] = PlayerPrefs.GetString("mouse3A");
            mouse[2, 1] = PlayerPrefs.GetString("mouse3B");
            mouse[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("mouse3CMD").Equals(2))
        {
            mouse[2, 0] = null;
            mouse[2, 1] = null;
            mouse[2, 2] = PlayerPrefs.GetString("mouse3C");
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

        if (PlayerPrefs.GetInt("pig2CMD").Equals(1))
        {
            pig[1, 0] = PlayerPrefs.GetString("pig2A");
            pig[1, 1] = PlayerPrefs.GetString("pig2B");
            pig[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("pig2CMD").Equals(2))
        {
            pig[1, 0] = null;
            pig[1, 1] = null;
            pig[1, 2] = PlayerPrefs.GetString("pig2C");
        }

        if (PlayerPrefs.GetInt("pig3CMD").Equals(1))
        {
            pig[2, 0] = PlayerPrefs.GetString("pig3A");
            pig[2, 1] = PlayerPrefs.GetString("pig3B");
            pig[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("pig3CMD").Equals(2))
        {
            pig[2, 0] = null;
            pig[2, 1] = null;
            pig[2, 2] = PlayerPrefs.GetString("pig3C");
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

        if (PlayerPrefs.GetInt("elephant2CMD").Equals(1))
        {
            elephant[1, 0] = PlayerPrefs.GetString("elephant2A");
            elephant[1, 1] = PlayerPrefs.GetString("elephant2B");
            elephant[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("elephant2CMD").Equals(2))
        {
            elephant[1, 0] = null;
            elephant[1, 1] = null;
            elephant[1, 2] = PlayerPrefs.GetString("elephant2C");
        }

        if (PlayerPrefs.GetInt("elephant3CMD").Equals(1))
        {
            elephant[2, 0] = PlayerPrefs.GetString("elephant3A");
            elephant[2, 1] = PlayerPrefs.GetString("elephant3B");
            elephant[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("elephant3CMD").Equals(2))
        {
            elephant[2, 0] = null;
            elephant[2, 1] = null;
            elephant[2, 2] = PlayerPrefs.GetString("elephant3C");
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

        if (PlayerPrefs.GetInt("lion2CMD").Equals(1))
        {
            lion[1, 0] = PlayerPrefs.GetString("lion2A");
            lion[1, 1] = PlayerPrefs.GetString("lion2B");
            lion[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("lion2CMD").Equals(2))
        {
            lion[1, 0] = null;
            lion[1, 1] = null;
            lion[1, 2] = PlayerPrefs.GetString("lion2C");
        }

        if (PlayerPrefs.GetInt("lion3CMD").Equals(1))
        {
            lion[2, 0] = PlayerPrefs.GetString("lion3A");
            lion[2, 1] = PlayerPrefs.GetString("lion3B");
            lion[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("lion3CMD").Equals(2))
        {
            lion[2, 0] = null;
            lion[2, 1] = null;
            lion[2, 2] = PlayerPrefs.GetString("lion3C");
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

        if (PlayerPrefs.GetInt("chicken2CMD").Equals(1))
        {
            chicken[1, 0] = PlayerPrefs.GetString("chicken2A");
            chicken[1, 1] = PlayerPrefs.GetString("chicken2B");
            chicken[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("chicken2CMD").Equals(2))
        {
            chicken[1, 0] = null;
            chicken[1, 1] = null;
            chicken[1, 2] = PlayerPrefs.GetString("chicken2C");
        }

        if (PlayerPrefs.GetInt("chicken3CMD").Equals(1))
        {
            chicken[2, 0] = PlayerPrefs.GetString("chicken3A");
            chicken[2, 1] = PlayerPrefs.GetString("chicken3B");
            chicken[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("chicken3CMD").Equals(2))
        {
            chicken[2, 0] = null;
            chicken[2, 1] = null;
            chicken[2, 2] = PlayerPrefs.GetString("chicken3C");
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

        if (PlayerPrefs.GetInt("kangaroo2CMD").Equals(1))
        {
            kangaroo[1, 0] = PlayerPrefs.GetString("kangaroo2A");
            kangaroo[1, 1] = PlayerPrefs.GetString("kangaroo2B");
            kangaroo[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("kangaroo2CMD").Equals(2))
        {
            kangaroo[1, 0] = null;
            kangaroo[1, 1] = null;
            kangaroo[1, 2] = PlayerPrefs.GetString("kangaroo2C");
        }

        if (PlayerPrefs.GetInt("kangaroo3CMD").Equals(1))
        {
            kangaroo[2, 0] = PlayerPrefs.GetString("kangaroo3A");
            kangaroo[2, 1] = PlayerPrefs.GetString("kangaroo3B");
            kangaroo[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("kangaroo3CMD").Equals(2))
        {
            kangaroo[2, 0] = null;
            kangaroo[2, 1] = null;
            kangaroo[2, 2] = PlayerPrefs.GetString("kangaroo3C");
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

        if (PlayerPrefs.GetInt("jiraffe2CMD").Equals(1))
        {
            jiraffe[1, 0] = PlayerPrefs.GetString("jiraffe2A");
            jiraffe[1, 1] = PlayerPrefs.GetString("jiraffe2B");
            jiraffe[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("jiraffe2CMD").Equals(2))
        {
            jiraffe[1, 0] = null;
            jiraffe[1, 1] = null;
            jiraffe[1, 2] = PlayerPrefs.GetString("jiraffe2C");
        }

        if (PlayerPrefs.GetInt("jiraffe3CMD").Equals(1))
        {
            jiraffe[2, 0] = PlayerPrefs.GetString("jiraffe3A");
            jiraffe[2, 1] = PlayerPrefs.GetString("jiraffe3B");
            jiraffe[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("jiraffe3CMD").Equals(2))
        {
            jiraffe[2, 0] = null;
            jiraffe[2, 1] = null;
            jiraffe[2, 2] = PlayerPrefs.GetString("jiraffe3C");
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

        if (PlayerPrefs.GetInt("buffalo2CMD").Equals(1))
        {
            buffalo[1, 0] = PlayerPrefs.GetString("buffalo2A");
            buffalo[1, 1] = PlayerPrefs.GetString("buffalo2B");
            buffalo[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("buffalo2CMD").Equals(2))
        {
            buffalo[1, 0] = null;
            buffalo[1, 1] = null;
            buffalo[1, 2] = PlayerPrefs.GetString("buffalo2C");
        }

        if (PlayerPrefs.GetInt("buffalo3CMD").Equals(1))
        {
            buffalo[2, 0] = PlayerPrefs.GetString("buffalo3A");
            buffalo[2, 1] = PlayerPrefs.GetString("buffalo3B");
            buffalo[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("buffalo3CMD").Equals(2))
        {
            buffalo[2, 0] = null;
            buffalo[2, 1] = null;
            buffalo[2, 2] = PlayerPrefs.GetString("buffalo3C");
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

        if (PlayerPrefs.GetInt("sheep2CMD").Equals(1))
        {
            sheep[1, 0] = PlayerPrefs.GetString("sheep2A");
            sheep[1, 1] = PlayerPrefs.GetString("sheep2B");
            sheep[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("sheep2CMD").Equals(2))
        {
            sheep[1, 0] = null;
            sheep[1, 1] = null;
            sheep[1, 2] = PlayerPrefs.GetString("sheep2C");
        }

        if (PlayerPrefs.GetInt("sheep3CMD").Equals(1))
        {
            sheep[2, 0] = PlayerPrefs.GetString("sheep3A");
            sheep[2, 1] = PlayerPrefs.GetString("sheep3B");
            sheep[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("sheep3CMD").Equals(2))
        {
            sheep[2, 0] = null;
            sheep[2, 1] = null;
            sheep[2, 2] = PlayerPrefs.GetString("sheep3C");
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

        if (PlayerPrefs.GetInt("wolf2CMD").Equals(1))
        {
            wolf[1, 0] = PlayerPrefs.GetString("wolf2A");
            wolf[1, 1] = PlayerPrefs.GetString("wolf2B");
            wolf[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("wolf2CMD").Equals(2))
        {
            wolf[1, 0] = null;
            wolf[1, 1] = null;
            wolf[1, 2] = PlayerPrefs.GetString("wolf2C");
        }

        if (PlayerPrefs.GetInt("wolf3CMD").Equals(1))
        {
            wolf[2, 0] = PlayerPrefs.GetString("wolf3A");
            wolf[2, 1] = PlayerPrefs.GetString("wolf3B");
            wolf[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("wolf3CMD").Equals(2))
        {
            wolf[2, 0] = null;
            wolf[2, 1] = null;
            wolf[2, 2] = PlayerPrefs.GetString("wolf3C");
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

        if (PlayerPrefs.GetInt("dog2CMD").Equals(1))
        {
            dog[1, 0] = PlayerPrefs.GetString("dog2A");
            dog[1, 1] = PlayerPrefs.GetString("dog2B");
            dog[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("dog2CMD").Equals(2))
        {
            dog[1, 0] = null;
            dog[1, 1] = null;
            dog[1, 2] = PlayerPrefs.GetString("dog2C");
        }

        if (PlayerPrefs.GetInt("dog3CMD").Equals(1))
        {
            dog[2, 0] = PlayerPrefs.GetString("dog3A");
            dog[2, 1] = PlayerPrefs.GetString("dog3B");
            dog[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("dog3CMD").Equals(2))
        {
            dog[2, 0] = null;
            dog[2, 1] = null;
            dog[2, 2] = PlayerPrefs.GetString("dog3C");
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

        if (PlayerPrefs.GetInt("cat2CMD").Equals(1))
        {
            cat[1, 0] = PlayerPrefs.GetString("cat2A");
            cat[1, 1] = PlayerPrefs.GetString("cat2B");
            cat[1, 2] = null;
        }
        else if (PlayerPrefs.GetInt("cat2CMD").Equals(2))
        {
            cat[1, 0] = null;
            cat[1, 1] = null;
            cat[1, 2] = PlayerPrefs.GetString("cat2C");
        }

        if (PlayerPrefs.GetInt("cat3CMD").Equals(1))
        {
            cat[2, 0] = PlayerPrefs.GetString("cat3A");
            cat[2, 1] = PlayerPrefs.GetString("cat3B");
            cat[2, 2] = null;
        }
        else if (PlayerPrefs.GetInt("cat3CMD").Equals(2))
        {
            cat[2, 0] = null;
            cat[2, 1] = null;
            cat[2, 2] = PlayerPrefs.GetString("cat3C");
        }
    }
}



