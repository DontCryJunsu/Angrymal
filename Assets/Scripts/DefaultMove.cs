using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefaultMove : MonoBehaviour {

    public GameObject goal;
    NavMeshAgent nav;
    bool JustWalk_isrunning;
    string[] command = new string[2];
    private Transform target;
    private float dist;

    void Awake()
    {
        var stat = GetComponent<stat>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = stat.SPEED;
    }


	// Use this for initialization
	void Start () {
        StartCoroutine("JustWalk");
        GetCommand();  //캐릭터에 맞는 command를 가져오는 함수
        
    }
	
	// Update is called once per frame
	void Update () {
         
   

        

        //////  RedDirector에 저장돼있는 조건이 만족할 때 RedDirector에 저장돼있는 행동과 같은 이름을 가진 코루틴을 실행한다.  ->  조건과 행동의 이름은 Start 함수에 있는 if문에 의해 string[] command 변수에 저장돼있음  //////

        
        
        switch (command[0])  //command[0]에는 조건의 이름, command[1]에는 행동의 이름이 저장되어 있다.
        {
            case "Always": //항상
                if (JustWalk_isrunning)  // 조건이 Always일 경우에는 JustWalk()가 실행 중인지 파악하고  JustWalk()를 종료시킨 후 동작한다. Always 외에 다른 이동 조건들도 그에 맞는 조건을 검사한 후에 JustWalk를 종료시킨 뒤 알맞는 행동을 실행시킨다.
                {
                    StopCoroutine("JustWalk");
                    JustWalk_isrunning = false;
                    StartCoroutine(command[1]);  //행동에 해당하는 이동명령(코루틴) 실행
                }
                break;
            //case "HPMoreThanHalf":  //체력이 절반 이상일 때
            //    if(stat.HP >= (stat.FULLHP)/2) 
            //    {
                    
            //    }
            //    break;
        }
        
	}

    IEnumerator JustWalk()
    {
        JustWalk_isrunning = true;
        while (true)
        {
            yield return null;
            nav.SetDestination(goal.transform.position);  //goal 오브젝트를 향해 이동
        }
    }


    IEnumerator ChaseClosestEnemy()
    {
      

        while (true)
        {
            yield return null;


            GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("bluecharacter");  //bluecharacter 태그의 모든 오브젝트를 찾는다.
            float closestDistSqr = Mathf.Infinity;  //가장 가까운 거리의 기본값.
            Transform closestEnemy = null;
            foreach (GameObject taggedEnemy in taggedEnemys)
            {
                Vector3 objectPos = taggedEnemy.transform.position;
                dist = (objectPos - transform.position).sqrMagnitude;
                if (dist < closestDistSqr)   // 거리가 제곱한 최단 거리보다 작으면
                {
                    closestDistSqr = dist;
                    closestEnemy = taggedEnemy.transform;
                }
            }
            target = closestEnemy;  //가장 가까운 적을 target으로 설정

            nav.SetDestination(target.position);  //target을 향해 이동
        }
    }

    void GetCommand()
    {
        if (name == "chicken")       //자신이 chicken이면 RedDirector의 command 중 chicken을 복사해 온다.
        {
            command[0] = GameObject.Find("RedDirector").GetComponent<Command>().chicken[0];
            command[1] = GameObject.Find("RedDirector").GetComponent<Command>().chicken[1];
        }
    }

}
