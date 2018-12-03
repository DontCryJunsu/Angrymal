using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using System.Reflection;  //문자열로 실행 시험

public class DefaultMove : MonoBehaviour
{

    public GameObject goal;
    NavMeshAgent nav;
    bool JustWalk_isrunning;
    //string[] command = new string[2];
    string[,] command = new string[4, 3];  //4행 2열. 1열은 조건, 2열은 행동. 각 행은 명령어 1개.
    private Transform target;
    private float dist;
    string runningact;
    int i = -1;
    int j = -1;
    bool checkcommand = true;
    bool checkattackcommand = true;
    public float hp;
    public float fullhp;
    public float speed;
    public float power;
    Collider akcoll = null;
    RandomDestination RD;





    // Use this for initialization
    void Start()
    {
        GetCommand();  //캐릭터에 맞는 command를 가져오는 함수
        var stat = GetComponent<stat>();
        nav = GetComponent<NavMeshAgent>();
        //fullhp = stat.FULLHP; hp = fullhp; speed = stat.SPEED; power = stat.POWER;  // 스탯 가져오기
        nav.speed = speed;
        StartCoroutine("JustWalk");
        StartCoroutine("CheckCommand");
        StartCoroutine("CheckAttackCommand");
        RD = goal.GetComponent<RandomDestination>();


    }

    // Update is called once per frame


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


    IEnumerator CheckAttackCommand()  // 공격 명령 기본 틀 미완성
    {


        while (true)
        {
            checkattackcommand = true;
            yield return null;

            if (tag == "redcharacter")
            {
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 5.0f);
                foreach (Collider coll in colls)
                {
                    if (coll != null)
                    {
                        if (coll.gameObject.tag == "bluecharacter")
                        {
                            while (checkattackcommand == true)
                            {
                                yield return null;
                                j++;
                                akcoll = coll;
                                if (command[j, 2] != null)
                                {
                                    yield return StartCoroutine(command[j, 2]);
                                }
                                nav.speed = speed;

                            }
                        }
                    }
                }
            }
            else if (tag == "bluecharacter")
            {
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 5.0f);
                foreach (Collider coll in colls)
                {
                    if (coll != null)
                    {
                        if (coll.gameObject.tag == "redcharacter")
                        {
                            while (checkattackcommand == true)
                            {
                                yield return null;
                                j++;
                                akcoll = coll;
                                if (command[j, 2] != null)
                                {
                                    yield return StartCoroutine(command[j, 2]);
                                }
                                nav.speed = speed;

                            }
                        }
                    }
                }
            }
            if (j >= 2 || checkattackcommand == false)
            {
                j = -1;
            }
        }


    }





    void GetCommand()
    {
        if (name == "chicken")       //자신이 chicken이면 RedDirector의 command 중 chicken을 복사해 온다.
        {
            command[0, 0] = Command.chicken[0, 0];
            command[0, 1] = Command.chicken[0, 1];
            command[1, 0] = Command.chicken[1, 0];
            command[1, 1] = Command.chicken[1, 1];
            command[0, 2] = Command.chicken[0, 2];
            command[1, 2] = Command.chicken[1, 2];

        }
        else if (name == "cat")
        {
            command[0, 0] = Command.cat[0, 0];
            command[0, 1] = Command.cat[0, 1];
        }
        else if (name == "sheep")
        {
            command[0, 0] = Command.sheep[0, 0];
            command[0, 1] = Command.sheep[0, 1];
            command[1, 0] = Command.sheep[1, 0];
            command[1, 1] = Command.sheep[1, 1];
            command[0, 2] = Command.sheep[0, 2];
        }
    }

    // 여기서부터 공격 조건

    IEnumerator AlwaysAttack()
    {
        nav.speed = 0;  // 멈춰 선다.
        transform.LookAt(akcoll.transform);  // 공격할 상대를 바라봄
        Debug.Log("Always Attack");
        checkattackcommand = false;
        yield return new WaitForSeconds(1.5f);
    }


    IEnumerator HPMoreThanHalfAttack()
    {
        if (hp >= (fullhp / 2))
        {
            nav.speed = 0;
            transform.LookAt(akcoll.transform);
            Debug.Log("HP more than half attack");
            checkattackcommand = false;
            yield return new WaitForSeconds(1.5f);
        }
    }


    IEnumerator HPLessThanHalfAttack()
    {
        if (hp < (fullhp / 2))
        {
            nav.speed = 0;
            transform.LookAt(akcoll.transform);
            Debug.Log("HP less than half attack");
            checkattackcommand = false;
            yield return new WaitForSeconds(1.5f);
        }
    }

    // 여기까지 공격 조건


    // 여기서부터 이동 조건

    void Always()
    {
        Debug.Log("Always");

        checkcommand = false;

        if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
        {
            StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
            StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
        
        }
        i = -1;

    }

    void HPMoreThanHalf()
    {



        if (hp >= (fullhp / 2))
        {
            Debug.Log("HPMoreThanHalf");
            checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


            if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
            {
                StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
                i = -1;
            }
        }
        return;
    }

    void HPLessThanHalf()
    {


        if (hp < (fullhp / 2))
        {
            Debug.Log("HPLessThanHalf");
            checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


            if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
            {
                StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
                i = -1;
            }
        }
        return;
    }

    void EnemyInNear()
    {

        Collider[] colls = Physics.OverlapSphere(this.transform.position, 15.0f);
        if (tag == "redcharacter")
        {
            foreach (Collider coll in colls)
            {
                if (coll.gameObject.tag == "bluecharacter")
                {
                    checkcommand = false;
                    if (runningact != command[i, 1])
                    {

                        StopCoroutine(runningact);
                        StartCoroutine(command[i, 1]);
                        //Debug.Log("A bluecharacter is detected in radius");
                        i = -1;
                        break;
                    }
                    i = -1;
                }


            }
        }
        else if (tag == "bluecharacter")
        {
            foreach (Collider coll in colls)
            {
                if (coll.gameObject.tag == "redcharacter")
                {
                    checkcommand = false;
                    if (runningact != command[i, 1])
                    {

                        StopCoroutine(runningact);
                        StartCoroutine(command[i, 1]);
                        // Debug.Log("A redcharacter is detected in radius");
                        i = -1;
                        break;
                    }
                    i = -1;
                }


            }
        }
    }


    void NoEnemyInNear()
    {

        Collider[] colls = Physics.OverlapSphere(this.transform.position, 15.0f);
        int nearenemy = 0;
        if (tag == "redcharacter")
        {
            foreach (Collider coll in colls)
            {
                if (coll.gameObject.tag == "bluecharacter")
                {
                    //Debug.Log("Enemy is in Near");
                    nearenemy++;
                }
            }
            if (nearenemy == 0)
            {
                checkcommand = false;
                if (runningact != command[i, 1])
                {

                    StopCoroutine(runningact);
                    StartCoroutine(command[i, 1]);
                    // Debug.Log("No Enemys in Near");
                    //i = -1;  //다시 쓸지도 모름

                }
                i = -1;
            }
        }
        else if (tag == "bluecharacter")
        {
            foreach (Collider coll in colls)
            {
                if (coll.gameObject.tag == "redcharacter")
                {
                    Debug.Log("Enemy is in Near");
                    nearenemy++;
                }
            }
            if (nearenemy == 0)
            {
                checkcommand = false;
                if (runningact != command[i, 1])
                {

                    StopCoroutine(runningact);
                    StartCoroutine(command[i, 1]);
                    Debug.Log("No Enemys in Near");
                    //i = -1;

                }
                i = -1;
            }
        }
    }

    // 여기까지 이동 조건



    // 여기서부터 이동 행동

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
            if (tag == "redcharacter")
            {
                GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("bluecharacter");  //bluecharacter 태그의 모든 오브젝트를 찾는다.
                if (taggedEnemys != null)
                {
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
            else if (tag == "bluecharacter")
            {
                GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("redcharacter");  //redcharacter 태그의 모든 오브젝트를 찾는다.
                if (taggedEnemys != null)
                {
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
        }
    }


    IEnumerator GoToEnemyTile()  
    {
        runningact = "GoToEnemyTile";
        bool gototile = false;
        //Debug.Log("Going to enemy tile");
        if (tag == "bluecharacter")
        {
            while (true)
            {
                yield return null;
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 15.0f);
                foreach (Collider coll in colls)
                {
                    // yield return null;
                    if (coll.gameObject.tag == "redteam")
                    {
                        nav.SetDestination(coll.gameObject.transform.position);
                        gototile = true;
                        break;
                    }
                    gototile = false;
                }
                if (gototile == false)
                {
                    RD.shuffle();
                    nav.SetDestination(goal.transform.position);
                }


            }
        }
        else if (tag =="redcharacter")
        {
            while (true)
            {
                yield return null;
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 15.0f);
                foreach (Collider coll in colls)
                {
                    // yield return null;
                    if (coll.gameObject.tag == "blueteam")
                    {
                        nav.SetDestination(coll.gameObject.transform.position);
                        gototile = true;
                        break;
                    }
                    gototile = false;
                }
                if (gototile == false)
                {
                    RD.shuffle();
                    nav.SetDestination(goal.transform.position);
                }


            }
        }
    }

    // 여기까지 이동 행동
}
