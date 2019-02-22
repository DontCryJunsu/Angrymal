using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Reflection;  //문자열로 실행 시험

 

public class DefaultMove : MonoBehaviour
{

    public GameObject goal;
    NavMeshAgent nav;
    bool JustWalk_isrunning;
    string[,] command = new string[1, 3];  //1행 3열. 1열은 조건, 2열은 행동. 각 행은 명령어 1개. 3열은 공격명령.
    private Transform target;
    private float dist;
    string runningact;
    int i = -1;
    int j = -1;
    bool checkcommand = true;
    
    public float hp;
    public float fullhp;
    public float speed;
    public float Orispeed;
    public float power;
    public float OriPower;
    public string child;
    public int num_of_tile; //총 땅의 개수
 
    RandomDestination RD;

    private int ckani;  
    public Animator animation;  //AlwaysAtk 스크립트에서 쓰려고 private->public으로 바꿈

    Rigidbody rgdy;
    Transform tr;
    PhotonView pv = null;

    private Vector3 currPos = Vector3.zero;
    private Quaternion currRot = Quaternion.identity;

    public Image HPBar;
    bool enemyinnear = false;

   

    void Awake()
    {
        num_of_tile = 280;
        Debug.Log("Awake 시작");
        rgdy = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();
        Orispeed = speed;
        OriPower = power;

        pv.synchronization = ViewSynchronization.UnreliableOnChange;
        pv.ObservedComponents[0] = this;

        //애니메이터 받아오기
        //animation = transform.FindChild(child).gameObject.GetComponent<Animator>();
        animation = transform.GetChild(0).GetComponent<Animator>();
        ckani = 0;

        GetCommand();  //캐릭터에 맞는 command를 가져오는 함수
        //var stat = GetComponent<stat>();
        nav = GetComponent<NavMeshAgent>();
        //fullhp = stat.FULLHP; hp = fullhp; speed = stat.SPEED; power = stat.POWER;  // 스탯 가져오기
        nav.speed = speed;
        //StartCoroutine("JustWalk");// <명령어 줄이기>
        runningact = "Nothing"; //<명령어 줄이기>
        StartCoroutine(CheckCommand());
        //if (name != "babychicken")
        //    StartCoroutine(CheckAttackCommand());
        RD = goal.GetComponent<RandomDestination>();

        if (!pv.isMine)
        {
            rgdy.isKinematic = true;
            nav.enabled = false;
        }
        currPos = tr.position;
        currRot = tr.rotation;
    }

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // 로컬 플레이어의 위치 정보 송신
        if (stream.isWriting)
        {
            stream.SendNext(this.hp);
            HPBar.fillAmount = hp / fullhp;
            if (this.hp <= 0)
            { GetComponent<PhotonView>().RPC("Die", PhotonTargets.AllViaServer); }
            
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        }
        // 원격 플레이어의 위치 정보 수신
        else
        {
            hp = (float)stream.ReceiveNext();
            //if (this.hp <= 0)
            //{ GetComponent<PhotonView>().RPC("Die", PhotonTargets.AllViaServer); }
            HPBar.fillAmount = hp / fullhp;
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
        }
    }

    void FixedUpdate()
    {
        if (!pv.isMine)
        {
            tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 3.0f);
            tr.rotation = Quaternion.Slerp(tr.rotation, currRot, Time.deltaTime * 3.0f);
        }

        if (Orispeed > speed)
        {
            speed += 0.01f;
            nav.speed = speed;
        }
        else if (Orispeed +0.5f < speed)
        {
            speed -= 0.05f;
            nav.speed = speed;
        }

        if (OriPower > power)
        {
            power += 0.01f;
        }
    }

   


    IEnumerator CheckCommand()
    {
        while (true)
        {

            ckani = 0; //애니메이터 변수 초기화

            yield return null;
            checkcommand = true;  //<명령어 줄이기>
            while (checkcommand == true)  // 조건에 맞는 명령어를 찾을때까지만 반복.
            {

         
                    
                    Invoke(command[0, 0], 0);
                
                if (enemyinnear==true)
                {
                    yield return new WaitForSeconds(3.0f);
                    enemyinnear = false;
                }
                
                 
                yield return new WaitForSeconds(0.1f);
                yield return null;
            }

        }
    }


    


    void GetCommand()
    {
        if (name == "chicken")
        {
            command[0, 0] = Command.chicken[0, 0];
            command[0, 1] = Command.chicken[0, 1];
            //command[0, 2] = Command.chicken[0, 2];

       
        }
        else if (name == "snake")
        {
            command[0, 0] = Command.snake[0, 0];
            command[0, 1] = Command.snake[0, 1];
            //command[0, 2] = Command.snake[0, 2];


        }
        else if (name == "mouse")
        {
            command[0, 0] = Command.mouse[0, 0];
            command[0, 1] = Command.mouse[0, 1];
            //command[0, 2] = Command.mouse[0, 2];

           
        }
        else if (name == "pig")
        {
            command[0, 0] = Command.pig[0, 0];
            command[0, 1] = Command.pig[0, 1];
           // command[0, 2] = Command.pig[0, 2];

    
        }
        else if (name == "elephant")
        {
            command[0, 0] = Command.elephant[0, 0];
            command[0, 1] = Command.elephant[0, 1];
           // command[0, 2] = Command.elephant[0, 2];

        
        }
        else if (name == "lion")
        {
            command[0, 0] = Command.lion[0, 0];
            command[0, 1] = Command.lion[0, 1];
           // command[0, 2] = Command.lion[0, 2];

    
        }
        else if (name == "kangaroo")
        {
            command[0, 0] = Command.kangaroo[0, 0];
            command[0, 1] = Command.kangaroo[0, 1];
          //  command[0, 2] = Command.kangaroo[0, 2];

          
        }
        else if (name == "jiraffe")
        {
            command[0, 0] = Command.jiraffe[0, 0];
            command[0, 1] = Command.jiraffe[0, 1];
          //  command[0, 2] = Command.jiraffe[0, 2];

       
        }
        else if (name == "buffalo")
        {
            command[0, 0] = Command.buffalo[0, 0];
            command[0, 1] = Command.buffalo[0, 1];
           // command[0, 2] = Command.buffalo[0, 2];


        }
        else if (name == "sheep")
        {
            command[0, 0] = Command.sheep[0, 0];
            command[0, 1] = Command.sheep[0, 1];
           // command[0, 2] = Command.sheep[0, 2];


        }
        else if (name == "wolf")
        {
            command[0, 0] = Command.wolf[0, 0];
            command[0, 1] = Command.wolf[0, 1];
           // command[0, 2] = Command.wolf[0, 2];

 
        }
        else if (name == "dog")
        {
            command[0, 0] = Command.dog[0, 0];
            command[0, 1] = Command.dog[0, 1];
           // command[0, 2] = Command.dog[0, 2];

   
        }
        else if (name == "cat")
        {
            command[0, 0] = Command.cat[0, 0];
            command[0, 1] = Command.cat[0, 1];
           // command[0, 2] = Command.cat[0, 2];


        }
        else if (name == "babychicken")
        {
            command[0, 0] = "Always";
            command[0, 1] = "JustWalk";
        }
    }

    // 여기서부터 공격 조건 ----------------------------------------------------------------------------------

 

    // 여기까지 공격 조건 --------------------------------------------------------------------------------------


    // 여기서부터 이동 조건 -----------------------------------------------------------------------------------

    void Always()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        checkcommand = false; //<명령어 줄이기>

        if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
        {
            StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
            StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작

        }
        //i = -1;

    }

    void HPMoreThanHalf()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);


        if (hp >= (fullhp / 2))
        {
            //  Debug.Log("HPMoreThanHalf");
            checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다. //<명령어 줄이기>


            if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작 //<명령어 줄이기>[i,1]
            {
                StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작  //<명령어 줄이기> [i,1]
                // i = -1; //<명령어 줄이기>
            }
        }//와드
        else  //<명령어 줄이기>
        {
            if (runningact != "JustWalk")
            {
                StopCoroutine(runningact);
                StartCoroutine("JustWalk");
            }
        }
        return;
    }

    void HPLessThanHalf()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        if (hp < (fullhp / 2))
        {
            //  Debug.Log("HPLessThanHalf");
            checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


            if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
            {
                StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작
                //i = -1;
            }
            
        }
        else  //<명령어 줄이기>
        {
            if (runningact != "JustWalk")
            {
                StopCoroutine(runningact);
                StartCoroutine("JustWalk");
            }
        }
        return;
    }

    void EnemyInNear()
    {
        //enemyinnear = false;
        ckani = 0;
        animation.SetInteger("ckani", ckani);

        Collider[] colls = Physics.OverlapSphere(this.transform.position, 10.0f);
        if (tag == "redcharacter")
        {
            foreach (Collider coll in colls)
            {
                if (coll.gameObject.tag == "bluecharacter")
                {
                    // checkcommand = false;
                  
                    if (runningact != command[0, 1])
                    {
                       
                        StopCoroutine(runningact);
                        StartCoroutine(command[0, 1]);
                        //Debug.Log("A bluecharacter is detected in radius");
                        //i = -1;
                        enemyinnear = true;
                        break;
                    }

                    //i = -1;
                }
            }
            if (enemyinnear == false)
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");
                     
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
                    if (runningact != command[0, 1])
                    {

                        StopCoroutine(runningact);
                        StartCoroutine(command[0, 1]);
                        // Debug.Log("A redcharacter is detected in radius");
                        //i = -1;
                        enemyinnear = true;
                        break;
                    }
                    //i = -1;
                }
            }
            if (enemyinnear == false)
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");

                }
            }
        }
    }


    void NoEnemyInNear()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        Collider[] colls = Physics.OverlapSphere(this.transform.position, 10.0f);
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
                if (runningact != command[0, 1])
                {

                    StopCoroutine(runningact);
                    StartCoroutine(command[0, 1]);
                    // Debug.Log("No Enemys in Near");
                    //i = -1;  //다시 쓸지도 모름 //<이건 명령어 줄이기 아님>

                }
                //i = -1;
            }
            else  //<명령어 줄이기>
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");
                }
            }
        }
        else if (tag == "bluecharacter")
        {
            foreach (Collider coll in colls)
            {
                if (coll.gameObject.tag == "redcharacter")
                {
                    //   Debug.Log("Enemy is in Near");
                    nearenemy++;
                }
            }
            if (nearenemy == 0)
            {
                checkcommand = false;
                if (runningact != command[0, 1])
                {

                    StopCoroutine(runningact);
                    StartCoroutine(command[0, 1]);
                    //   Debug.Log("No Enemys in Near");
                    //i = -1;

                }
                //i = -1;
            }
            else  //<명령어 줄이기>
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");
                }
            }
        }
    }

    void OurTileIsMore()  //땅이 더 많을 때
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        if (tag == "redcharacter")
        {
            if (Command.redtile > Command.bluetile)
            {
                //  Debug.Log("OurTileIsMore");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작
                    //i = -1;
                }
            }
            else  //<명령어 줄이기>
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");
                }
            }
        }
        else if (tag == "bluecharacter")
        {
            if (Command.bluetile > Command.redtile)
            {
                //  Debug.Log("OurTileIsMore");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작
                    //i = -1;
                }
            }
            else  //<명령어 줄이기>
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");
                }
            }
        }
        return;
    }

    void OurTileIsLess()  //땅이 더 적을 때
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        if (tag == "redcharacter")
        {
            if (Command.redtile < Command.bluetile)
            {
                Debug.Log("레드땅이 더 적음");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작
                    //i = -1;
                }
            }
            else  //<명령어 줄이기>
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");
                }
            }
        }
        else if (tag == "bluecharacter")
        {
            if (Command.bluetile < Command.redtile)
            {
                //  Debug.Log("OurTileIsMoreLess");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작
                    //i = -1;
                }
            }
            else  //<명령어 줄이기>
            {
                if (runningact != "JustWalk")
                {
                    StopCoroutine(runningact);
                    StartCoroutine("JustWalk");
                }
            }
        }
        return;
    }



    void NoEmptyTile()  // 빈 땅이 없을 때
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        if ((Command.redtile + Command.bluetile) >= num_of_tile)
        {
            //  Debug.Log("OurTileIsLess");
            checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


            if (runningact != command[0, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
            {
                StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                StartCoroutine(command[0, 1]);  //지금 실행해야 할 행동 시작
                //i = -1;
            }
        }
        else  //<명령어 줄이기>
        {
            if (runningact != "JustWalk")
            {
                StopCoroutine(runningact);
                StartCoroutine("JustWalk");
            }
        }
        return;
    }
    // 여기까지 이동 조건 -----------------------------------------------------------------------------------------



    // 여기서부터 이동 행동 ----------------------------------------------------------------------------------------

    IEnumerator JustWalk()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        JustWalk_isrunning = true;
        runningact = "JustWalk";
        while (true)
        {
            Debug.Log("runningact is JustWalk");
            yield return null;
            nav.SetDestination(goal.transform.position);  //goal 오브젝트를 향해 이동
        }
    }

    IEnumerator ChaseClosestEnemy()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        while (true)
        {
            Debug.Log("가까운적 코루틴 실행");
            yield return null;
            runningact = "ChaseClosestEnemy";
            if (tag == "redcharacter")
            {
                //Debug.Log("이것은 레드캐릭터");

                GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("bluecharacter");  //bluecharacter 태그의 모든 오브젝트를 찾는다.
               // Debug.Log("Find 끝");
                //Debug.Log("길이 " + taggedEnemys.Length);
                
                if (taggedEnemys != null && taggedEnemys.Length>0)
                {
                   // Debug.Log("null 아닐때 진입");
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
                   // Debug.Log("적을향해");
                }
              
               // Debug.Log("if문 else문 통과");

            }
            else if (tag == "bluecharacter")
            {
                GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("redcharacter");  //redcharacter 태그의 모든 오브젝트를 찾는다.
                if (taggedEnemys != null && taggedEnemys.Length > 0)
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


    IEnumerator ChaseClosestAlly()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        while (true)
        {
            yield return null;
            runningact = "ChaseClosestAlly";
            if (tag == "redcharacter")
            {
                GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("redcharacter");  //bluecharacter 태그의 모든 오브젝트를 찾는다.
                if (taggedEnemys != null)
                {
                    float closestDistSqr = Mathf.Infinity;  //가장 가까운 거리의 기본값.
                    Transform closestEnemy = null;
                    foreach (GameObject taggedEnemy in taggedEnemys)
                    {
                        // if (taggedEnemy.transform.name != transform.name)      //같은동물끼리는 안쫓아감
                        //{
                        Vector3 objectPos = taggedEnemy.transform.position;
                        dist = (objectPos - transform.position).sqrMagnitude;

                        if (dist < closestDistSqr && dist != 0)   // 거리가 제곱한 최단 거리보다 작으면
                        {
                            closestDistSqr = dist;
                            closestEnemy = taggedEnemy.transform;
                        }
                        // }

                    }
                    if (closestEnemy != null)
                    {
                        target = closestEnemy;  //가장 가까운 아군을 target으로 설정
                        nav.SetDestination(target.position);  //target을 향해 이동
                    }
                }

            }
            else if (tag == "bluecharacter")
            {
                GameObject[] taggedEnemys = GameObject.FindGameObjectsWithTag("bluecharacter");  //redcharacter 태그의 모든 오브젝트를 찾는다.
                if (taggedEnemys != null)
                {
                    float closestDistSqr = Mathf.Infinity;  //가장 가까운 거리의 기본값.
                    Transform closestEnemy = null;
                    foreach (GameObject taggedEnemy in taggedEnemys)
                    {
                        Vector3 objectPos = taggedEnemy.transform.position;
                        dist = (objectPos - transform.position).sqrMagnitude;
                        if (dist < closestDistSqr && dist != 0)   // 거리가 제곱한 최단 거리보다 작으면
                        {
                            closestDistSqr = dist;
                            closestEnemy = taggedEnemy.transform;
                        }
                    }
                    if (closestEnemy != null)
                    {
                        target = closestEnemy;  //가장 가까운 아군을 target으로 설정
                        nav.SetDestination(target.position);  //target을 향해 이동
                    }
                }

            }
        }
    }


    IEnumerator GoToEnemyTile()
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        runningact = "GoToEnemyTile";
        bool gototile = false;
        //Debug.Log("Going to enemy tile");
        if (tag == "bluecharacter")
        {
            while (true)
            {
                //yield return null;
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 7.0f);
                foreach (Collider coll in colls)
                {
                    yield return null;
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
                    if (Command.redtile != 0)  //적 땅이 존재할 경우에만
                    {
                        RD.shuffle();
                        nav.SetDestination(goal.transform.position);
                    }

                }


            }
        }
        else if (tag == "redcharacter")
        {
            while (true)
            {
                yield return null;
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 7.0f);
                foreach (Collider coll in colls)
                {
                    yield return null;
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
                    if (Command.bluetile != 0)
                    {
                        RD.shuffle();
                        nav.SetDestination(goal.transform.position);
                    }
                }


            }
        }
    }


    IEnumerator GoToEmtyTile()  // 빈 땅으로 이동
    {

        ckani = 0;
        animation.SetInteger("ckani", ckani);

        runningact = "GoToEmtyTile";
        bool gototile = false;
        //Debug.Log("Going to enemy tile");

        while (true)
        {
            //yield return null;
            Collider[] colls = Physics.OverlapSphere(this.transform.position, 4.0f);
            foreach (Collider coll in colls)
            {
                yield return null;
                if (coll.gameObject.tag == "Untagged")
                {
                    nav.SetDestination(coll.gameObject.transform.position);
                    gototile = true;
                    break;
                }
                gototile = false;
            }
            if (gototile == false)
            {
                if ((Command.redtile + Command.bluetile) < num_of_tile)  //빈 땅이 존재할 경우에만
                {
                    RD.shuffleempty();
                    nav.SetDestination(goal.transform.position);
                }

            }
        }
    }


    // 여기까지 이동 행동 ----------------------------------------------------------------------------------------


    [PunRPC]
    public void Poison()
    {
        if (hp > 0)
        {
            hp -= 0.05f;
        }
        // pv.RPC("AttackProcess", PhotonTargets.All, attackTarget, damage);
    }

     
    [PunRPC]
    public void Die()
    {
        GameObject.Find("BattleManager").GetComponent<BattleManager>().Die(this.gameObject);
    }
   
   






    // ---------------------공격조건 백업-------------------
    //IEnumerator AlwaysAttack()
    //{
    //    //애니메이터
    //    ckani = 1;
    //    animation.SetInteger("ckani", ckani);

    //    ///destinationbuffer = nav.destination;  //공격 끝나면 목표지점 돌려놓으려고 목표지점 저장해놓음

    //    nav.speed = 0;  // 멈춰 선다.
    //    transform.LookAt(akcoll.transform);  // 공격할 상대를 바라봄
    //    angularbuffer = nav.angularSpeed;
    //    nav.angularSpeed = 0;


    //    Debug.Log("항상공격");
    //    //isAttack = true;
    //    // animation.SetBool("isAttack", isAttack); //애니메이션세팅
    //    ckani = 1;
    //    animation.SetInteger("ckani", ckani);

    //    nav.speed = 0;  // 멈춰 선다.
    //    transform.LookAt(akcoll.transform);  // 공격할 상대를 바라봄


    //    akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.All, Time.deltaTime);
    //    transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //    yield return null;
    //    //NetAttackDamage(power)destination;
    //    Debug.Log("항상 공격");


    //    //checkattackcommand = false; //<명령어 줄이기>
    //    yield return new WaitForSeconds(0.5f);
    //    transform.GetChild(1).gameObject.SetActive(false);
    //    yield return new WaitForSeconds(1.0f);
    //    nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음
    //   // nav.SetDestination(destinationbuffer); //navmesh 목표지점 원래대로 돌려놈

    //}


    //IEnumerator HPMoreThanHalfAttack()
    //{

    //    if (hp >= (fullhp / 2))
    //    {

    //        //애니메이터
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);

    //        nav.speed = 0;
    //        transform.LookAt(akcoll.transform);
    //        angularbuffer = nav.angularSpeed;
    //        nav.angularSpeed = 0;

    //        Debug.Log("절반이상공격");
    //        // isAttack = true;
    //        // animation.SetBool("isAttack", isAttack); //애니메이션세팅
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);
    //        nav.speed = 0;
    //        transform.LookAt(akcoll.transform);

    //        akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //        transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //        yield return null;

    //        Debug.Log("HP more than half attack");
    //        checkattackcommand = false;
    //        yield return new WaitForSeconds(1.5f);

    //        transform.GetChild(1).gameObject.SetActive(false);
    //        nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음
    //    }

    //}


    //IEnumerator HPLessThanHalfAttack()
    //{
    //    if (hp < (fullhp / 2))
    //    {

    //        //애니메이터
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);

    //        Debug.Log("절반이하공격");
    //        // isAttack = true;
    //        //animation.SetBool("isAttack", isAttack); //애니메이션세팅
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);

    //        nav.speed = 0;
    //        transform.LookAt(akcoll.transform);
    //        angularbuffer = nav.angularSpeed;
    //        nav.angularSpeed = 0;



    //        akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //        transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //        yield return null;

    //        Debug.Log("HP less than half attack");
    //        checkattackcommand = false;
    //        yield return new WaitForSeconds(1.5f);

    //        transform.GetChild(1).gameObject.SetActive(false);
    //        nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음
    //    }
    //}

    //IEnumerator EnemyHPMoreThanHalfAttack()  // 상대 체력 절반 이상일 때 공격
    //{

    //    var enemyhp = akcoll.GetComponent<DefaultMove>();
    //    if (enemyhp.hp >= (enemyhp.fullhp / 2))
    //    {


    //        //애니메이터
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);

    //        nav.speed = 0;
    //        transform.LookAt(akcoll.transform);
    //        angularbuffer = nav.angularSpeed;
    //        nav.angularSpeed = 0;

    //        akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //        transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //        yield return null;

    //        Debug.Log("Enemy HP more than half attack");
    //        checkattackcommand = false;
    //        yield return new WaitForSeconds(1.5f);

    //        transform.GetChild(1).gameObject.SetActive(false);
    //        nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음

    //    }
    //}


    //IEnumerator EnemyHPLessThanHalfAttack()  // 상대 체력 절반 미만일 때 공격
    //{

    //    var enemyhp = akcoll.GetComponent<DefaultMove>();
    //    if (enemyhp.hp < (enemyhp.fullhp / 2))
    //    {

    //        //애니메이터
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);

    //        nav.speed = 0;
    //        transform.LookAt(akcoll.transform);
    //        angularbuffer = nav.angularSpeed;
    //        nav.angularSpeed = 0;

    //        akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //        transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //        yield return null;

    //        Debug.Log("Enemy HP less than half attack");
    //        checkattackcommand = false;
    //        yield return new WaitForSeconds(1.5f);

    //        transform.GetChild(1).gameObject.SetActive(false);
    //        nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음

    //    }
    //}

    //IEnumerator MyHPIsMoreAttack()  // 내 체력이 더 많을 때 공격
    //{

    //    var enemyhp = akcoll.GetComponent<DefaultMove>();
    //    if (enemyhp.hp < hp)
    //    {

    //        //애니메이터
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);

    //        nav.speed = 0;
    //        transform.LookAt(akcoll.transform);
    //        angularbuffer = nav.angularSpeed;
    //        nav.angularSpeed = 0;

    //        akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //        transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //        yield return null;

    //        Debug.Log("My HP is more than enemy's HP Attack");
    //        checkattackcommand = false;
    //        yield return new WaitForSeconds(1.5f);

    //        transform.GetChild(1).gameObject.SetActive(false);
    //        nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음

    //    }
    //    yield return null;
    //}

    //IEnumerator OurTileIsMoreAttack()   // 땅이 더 많을 때 공격
    //{

    //    if (tag == "redcharacter")
    //    {
    //        if (Command.redtile > Command.bluetile)
    //        {

    //            //애니메이터
    //            ckani = 1;
    //            animation.SetInteger("ckani", ckani);

    //            nav.speed = 0;   // 멈추고
    //            transform.LookAt(akcoll.transform);  //적 바라봄
    //            angularbuffer = nav.angularSpeed;
    //            nav.angularSpeed = 0;

    //            akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //            transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //            yield return null;

    //            Debug.Log("Our tile is more than enemy's tile Attack");  // 공격
    //            checkattackcommand = false;
    //            yield return new WaitForSeconds(1.5f);

    //            transform.GetChild(1).gameObject.SetActive(false);
    //            nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음

    //        }
    //    }
    //    else if (tag == "bluecharacter")
    //    {
    //        if (Command.bluetile > Command.redtile)
    //        {

    //            //애니메이터
    //            ckani = 1;
    //            animation.SetInteger("ckani", ckani);

    //            nav.speed = 0;
    //            transform.LookAt(akcoll.transform);
    //            angularbuffer = nav.angularSpeed;
    //            nav.angularSpeed = 0;

    //            akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //            transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //            yield return null;

    //            Debug.Log("My tile is more than enemy's tile Attack");
    //            checkattackcommand = false;
    //            yield return new WaitForSeconds(1.5f);

    //            transform.GetChild(1).gameObject.SetActive(false);
    //            nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음

    //        }
    //    }
    //    yield return null;
    //}

    //IEnumerator OurTileIsLessAttack()
    //{

    //    if (tag == "redcharacter")
    //    {
    //        if (Command.redtile < Command.bluetile)
    //        {

    //            //애니메이터
    //            ckani = 1;
    //            animation.SetInteger("ckani", ckani);

    //            nav.speed = 0;   // 멈추고
    //            transform.LookAt(akcoll.transform);  //적 바라봄
    //            angularbuffer = nav.angularSpeed;
    //            nav.angularSpeed = 0;

    //            akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //            transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //            yield return null;

    //            Debug.Log("Our tile is less than enemy's tile Attack");  // 공격
    //            checkattackcommand = false;
    //            yield return new WaitForSeconds(1.5f);

    //            transform.GetChild(1).gameObject.SetActive(false);
    //            nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음
    //        }
    //    }
    //    else if (tag == "bluecharacter")
    //    {
    //        if (Command.bluetile < Command.redtile)
    //        {

    //            Debug.Log("땅적을때");
    //            // isAttack = true;
    //            // animation.SetBool("isAttack", isAttack); //애니메이션세팅
    //            ckani = 1;
    //            animation.SetInteger("ckani", ckani);
    //            nav.speed = 0;
    //            transform.LookAt(akcoll.transform);

    //            angularbuffer = nav.angularSpeed;
    //            nav.angularSpeed = 0;

    //            akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //            transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //            yield return null;

    //            Debug.Log("My tile is less than enemy's tile Attack");
    //            checkattackcommand = false;
    //            yield return new WaitForSeconds(1.5f);

    //            transform.GetChild(1).gameObject.SetActive(false);
    //            nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음
    //        }
    //    }
    //    yield return null;
    //}

    //IEnumerator NoEmptyTileAttack()   // 빈 땅이 없을 때 공격
    //{

    //    if ((Command.redtile + Command.bluetile) >= num_of_tile)
    //    {

    //        //애니메이터
    //        ckani = 1;
    //        animation.SetInteger("ckani", ckani);

    //        nav.speed = 0;   // 멈추고
    //        transform.LookAt(akcoll.transform);  //적 바라봄
    //        angularbuffer = nav.angularSpeed;
    //        nav.angularSpeed = 0;

    //        akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
    //        transform.GetChild(1).gameObject.SetActive(true);  //공격 
    //        yield return null;
    //        Debug.Log("There are no empty tile Attack");  // 공격
    //        checkattackcommand = false;
    //        yield return new WaitForSeconds(1.5f);

    //        transform.GetChild(1).gameObject.SetActive(false);
    //        nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음

    //    }
    //}
}
