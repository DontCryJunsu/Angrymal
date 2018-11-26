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
    public string[,] chicken = new string[4,2];
	// Use this for initialization

	void Start () {
        chicken[0,0] = "Always";           // 0번은 조건
        chicken[0,1] = "ChaseClosestEnemy";     // 1번은 행동
        
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



