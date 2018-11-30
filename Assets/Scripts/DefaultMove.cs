using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using System.Reflection;  //문자열로 실행 시험

public class DefaultMove : MonoBehaviour {

    public GameObject goal;
    NavMeshAgent nav;
    bool JustWalk_isrunning;
    //string[] command = new string[2];
    string[,] command = new string[4, 2];  //4행 2열. 1열은 조건, 2열은 행동. 각 행은 명령어 1개.
    private Transform target;
    private float dist;
    string runningact;
    int i = -1;
    bool checkcommand = true;
    public float hp;
    public float fullhp;
    public float speed;
    public float power;

    void Awake()
    {
       
    }


	// Use this for initialization
	void Start () {
        GetCommand();  //캐릭터에 맞는 command를 가져오는 함수
        var stat = GetComponent<stat>();
        nav = GetComponent<NavMeshAgent>();
        fullhp = stat.FULLHP; hp = fullhp; speed = stat.SPEED; power = stat.POWER;  // 스탯 가져오기
        nav.speed = speed;
        StartCoroutine("JustWalk");
        StartCoroutine("CheckCommand");
        

    }
	
	// Update is called once per frame
	void Update () {
        
         

    

        // Invoke(command[0,0], 0);   -> 조건 호출 방법.


        //////  RedDirector에 저장돼있는 조건이 만족할 때 RedDirector에 저장돼있는 행동과 같은 이름을 가진 코루틴을 실행한다.  ->  조건과 행동의 이름은 Start 함수에 있는 if문에 의해 string[] command 변수에 저장돼있음  //////

        /*  switch case 문
        
        switch (command[0,0])  //command[0]에는 조건의 이름, command[1]에는 행동의 이름이 저장되어 있다.
        {
            case "Always": //항상
                if (JustWalk_isrunning)  // 조건이 Always일 경우에는 JustWalk()가 실행 중인지 파악하고  JustWalk()를 종료시킨 후 동작한다. Always 외에 다른 이동 조건들도 그에 맞는 조건을 검사한 후에 JustWalk를 종료시킨 뒤 알맞는 행동을 실행시킨다.
                {
                    StopCoroutine("JustWalk");
                    JustWalk_isrunning = false;
                    StartCoroutine(command[0,1]);  //행동에 해당하는 이동명령(코루틴) 실행
                }
                break;
                
            // case "HPMoreThanHalf":  //체력이 절반 이상일 때
                //if(stat.HP >= (stat.FULLHP)/2) 
                //{
                    
                //}
                //break;
                
        }

    */  //  switch case 문

    }

    IEnumerator CheckCommand()
    {
        while (true)
        {
            yield return null;
            checkcommand = true;
            while (checkcommand == true)  // 조건에 맞는 명령어를 찾을때까지만 반복.
            {
                
                i++;  //

                Invoke(command[i, 0], 0);  // command[i,0]에는 각 명령어의 조건이 들어있다. 각 조건은 이 스크립트의 맨 아래쪽에 메서드로 구현해놓는다.

                if (i >= 3)
                {
                    i = -1;  // 각 명령어를 반복해 검사하기 위함.
                }

                yield return null;
            }
           
        }
    }
  
  


   

    void GetCommand()
    {
        if (name == "chicken")       //자신이 chicken이면 RedDirector의 command 중 chicken을 복사해 온다.
        {
            command[0,0] = Command.chicken[0,0];
            command[0,1] = Command.chicken[0,1];
            command[1, 0] = Command.chicken[1, 0];
            command[1, 1] = Command.chicken[1, 1];

        }
        else if (name == "cat")     
        {
            command[0, 0] = Command .cat[0, 0];
            command[0, 1] = Command .cat[0, 1];
        }
    }



    // 여기서부터 조건

    void Always()
    {
        Debug.Log("Always");
         
        checkcommand = false;
        
        if (runningact != command[i,1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
        {
            StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
            StartCoroutine(command[i,1]);  //지금 실행해야 할 행동 시작
            i = -1;
        }
     
        
    }

    void HPMoreThanHalf()
    {
       


        if (hp >= (fullhp / 2))
        {
            Debug.Log("HPMoreThanHalf");
            checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


            /*   
            
            runningact에 해당하는 행동 종료.

            해당하는 행동을 실행하는 코드를 만들어 넣을 것 (  ex) command[i,1]).

             */

            if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
            {
                StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
                i = -1;
            }
        }
        return;
    }

    void EnemyInNear()   //테스트
    {
        Collider[] colls = Physics.OverlapSphere(this.transform.position, 1.0f);
        foreach(Collider coll in colls)
        {
            if (coll.tag == "bluecharacter") ;
            {
                checkcommand = false;
                StopCoroutine(runningact);
                Debug.Log("A bluecharacter is detected in radius");
                
                 
            }
        }
        
        
    }

    // 여기까지 조건


    // 여기서부터 행동

    IEnumerator JustWalk()
    {
        JustWalk_isrunning = true;
        runningact = "JustWalk";
        //Debug.Log("runningact is JustWalk");
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
            runningact = "ChaseClosestEnemy";

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


    // 여기까지 행동
}
