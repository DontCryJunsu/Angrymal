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
    string[,] command = new string[4, 3];  //4행 3열. 1열은 조건, 2열은 행동. 각 행은 명령어 1개. 3열은 공격명령.
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
    public int num_of_tile = 275; //총 땅의 개수
    Collider akcoll = null;
    RandomDestination RD;

    Rigidbody rgdy;
    Transform tr;
    PhotonView pv = null;

    private Vector3 currPos = Vector3.zero;
    private Quaternion currRot = Quaternion.identity;

    void Awake()
    {
        rgdy = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();

        pv.synchronization = ViewSynchronization.UnreliableOnChange;
        pv.ObservedComponents[0] = this;

        GetCommand();  //캐릭터에 맞는 command를 가져오는 함수
        //var stat = GetComponent<stat>();
        nav = GetComponent<NavMeshAgent>();
        //fullhp = stat.FULLHP; hp = fullhp; speed = stat.SPEED; power = stat.POWER;  // 스탯 가져오기
        nav.speed = speed;
        StartCoroutine("JustWalk");
        StartCoroutine("CheckCommand");
        StartCoroutine("CheckAttackCommand");
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
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        }
        // 원격 플레이어의 위치 정보 수신
        else
        {
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


    IEnumerator CheckAttackCommand()  // 공격 명령 기본 틀
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
                                if (j >= 2 || checkattackcommand == false)
                                {
                                    j = -1;
                                }
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
                                    //Debug.Log("J = " + j);
                                }
                                nav.speed = speed;
                                if (j >= 2 || checkattackcommand == false)
                                {
                                    j = -1;
                                }
                            }
                        }
                    }
                }
            }

        }
    }





    void GetCommand()
    {
        if (name == "chicken")
        {
            command[0, 0] = Command.chicken[0, 0];
            command[0, 1] = Command.chicken[0, 1];
            command[0, 2] = Command.chicken[0, 2];
            command[1, 0] = Command.chicken[1, 0];
            command[1, 1] = Command.chicken[1, 1];
            command[1, 2] = Command.chicken[1, 2];
            command[2, 0] = Command.chicken[2, 0];
            command[2, 1] = Command.chicken[2, 1];
            command[2, 2] = Command.chicken[2, 2];
            command[2, 0] = Command.chicken[3, 0];
            command[2, 1] = Command.chicken[3, 1];
        }
        else if (name == "snake")
        {
            command[0, 0] = Command.snake[0, 0];
            command[0, 1] = Command.snake[0, 1];
            command[0, 2] = Command.snake[0, 2];
            command[1, 0] = Command.snake[1, 0];
            command[1, 1] = Command.snake[1, 1];
            command[1, 2] = Command.snake[1, 2];
            command[2, 0] = Command.snake[2, 0];
            command[2, 1] = Command.snake[2, 1];
            command[2, 2] = Command.snake[2, 2];
            command[2, 0] = Command.snake[3, 0];
            command[2, 1] = Command.snake[3, 1];
        }
        else if (name == "mouse")
        {
            command[0, 0] = Command.mouse[0, 0];
            command[0, 1] = Command.mouse[0, 1];
            command[0, 2] = Command.mouse[0, 2];
            command[1, 0] = Command.mouse[1, 0];
            command[1, 1] = Command.mouse[1, 1];
            command[1, 2] = Command.mouse[1, 2];
            command[2, 0] = Command.mouse[2, 0];
            command[2, 1] = Command.mouse[2, 1];
            command[2, 2] = Command.mouse[2, 2];
            command[2, 0] = Command.mouse[3, 0];
            command[2, 1] = Command.mouse[3, 1];
        }
        else if (name == "pig")
        {
            command[0, 0] = Command.pig[0, 0];
            command[0, 1] = Command.pig[0, 1];
            command[0, 2] = Command.pig[0, 2];
            command[1, 0] = Command.pig[1, 0];
            command[1, 1] = Command.pig[1, 1];
            command[1, 2] = Command.pig[1, 2];
            command[2, 0] = Command.pig[2, 0];
            command[2, 1] = Command.pig[2, 1];
            command[2, 2] = Command.pig[2, 2];
            command[2, 0] = Command.pig[3, 0];
            command[2, 1] = Command.pig[3, 1];
        }
        else if (name == "elephant")
        {
            command[0, 0] = Command.elephant[0, 0];
            command[0, 1] = Command.elephant[0, 1];
            command[0, 2] = Command.elephant[0, 2];
            command[1, 0] = Command.elephant[1, 0];
            command[1, 1] = Command.elephant[1, 1];
            command[1, 2] = Command.elephant[1, 2];
            command[2, 0] = Command.elephant[2, 0];
            command[2, 1] = Command.elephant[2, 1];
            command[2, 2] = Command.elephant[2, 2];
            command[2, 0] = Command.elephant[3, 0];
            command[2, 1] = Command.elephant[3, 1];
        }
        else if (name == "lion")
        {
            command[0, 0] = Command.lion[0, 0];
            command[0, 1] = Command.lion[0, 1];
            command[0, 2] = Command.lion[0, 2];
            command[1, 0] = Command.lion[1, 0];
            command[1, 1] = Command.lion[1, 1];
            command[1, 2] = Command.lion[1, 2];
            command[2, 0] = Command.lion[2, 0];
            command[2, 1] = Command.lion[2, 1];
            command[2, 2] = Command.lion[2, 2];
            command[2, 0] = Command.lion[3, 0];
            command[2, 1] = Command.lion[3, 1];
        }
        else if (name == "kangaroo")
        {
            command[0, 0] = Command.kangaroo[0, 0];
            command[0, 1] = Command.kangaroo[0, 1];
            command[0, 2] = Command.kangaroo[0, 2];
            command[1, 0] = Command.kangaroo[1, 0];
            command[1, 1] = Command.kangaroo[1, 1];
            command[1, 2] = Command.kangaroo[1, 2];
            command[2, 0] = Command.kangaroo[2, 0];
            command[2, 1] = Command.kangaroo[2, 1];
            command[2, 2] = Command.kangaroo[2, 2];
            command[2, 0] = Command.kangaroo[3, 0];
            command[2, 1] = Command.kangaroo[3, 1];
        }
        else if (name == "jiraffe")
        {
            command[0, 0] = Command.jiraffe[0, 0];
            command[0, 1] = Command.jiraffe[0, 1];
            command[0, 2] = Command.jiraffe[0, 2];
            command[1, 0] = Command.jiraffe[1, 0];
            command[1, 1] = Command.jiraffe[1, 1];
            command[1, 2] = Command.jiraffe[1, 2];
            command[2, 0] = Command.jiraffe[2, 0];
            command[2, 1] = Command.jiraffe[2, 1];
            command[2, 2] = Command.jiraffe[2, 2];
            command[2, 0] = Command.jiraffe[3, 0];
            command[2, 1] = Command.jiraffe[3, 1];
        }
        else if (name == "buffalo")
        {
            command[0, 0] = Command.buffalo[0, 0];
            command[0, 1] = Command.buffalo[0, 1];
            command[0, 2] = Command.buffalo[0, 2];
            command[1, 0] = Command.buffalo[1, 0];
            command[1, 1] = Command.buffalo[1, 1];
            command[1, 2] = Command.buffalo[1, 2];
            command[2, 0] = Command.buffalo[2, 0];
            command[2, 1] = Command.buffalo[2, 1];
            command[2, 2] = Command.buffalo[2, 2];
            command[2, 0] = Command.buffalo[3, 0];
            command[2, 1] = Command.buffalo[3, 1];
        }
        else if (name == "sheep")
        {
            command[0, 0] = Command.sheep[0, 0];
            command[0, 1] = Command.sheep[0, 1];
            command[0, 2] = Command.sheep[0, 2];
            command[1, 0] = Command.sheep[1, 0];
            command[1, 1] = Command.sheep[1, 1];
            command[1, 2] = Command.sheep[1, 2];
            command[2, 0] = Command.sheep[2, 0];
            command[2, 1] = Command.sheep[2, 1];
            command[2, 2] = Command.sheep[2, 2];
            command[2, 0] = Command.sheep[3, 0];
            command[2, 1] = Command.sheep[3, 1];
        }
        else if (name == "wolf")
        {
            command[0, 0] = Command.wolf[0, 0];
            command[0, 1] = Command.wolf[0, 1];
            command[0, 2] = Command.wolf[0, 2];
            command[1, 0] = Command.wolf[1, 0];
            command[1, 1] = Command.wolf[1, 1];
            command[1, 2] = Command.wolf[1, 2];
            command[2, 0] = Command.wolf[2, 0];
            command[2, 1] = Command.wolf[2, 1];
            command[2, 2] = Command.wolf[2, 2];
            command[2, 0] = Command.wolf[3, 0];
            command[2, 1] = Command.wolf[3, 1];
        }
        else if (name == "dog")
        {
            command[0, 0] = Command.dog[0, 0];
            command[0, 1] = Command.dog[0, 1];
            command[0, 2] = Command.dog[0, 2];
            command[1, 0] = Command.dog[1, 0];
            command[1, 1] = Command.dog[1, 1];
            command[1, 2] = Command.dog[1, 2];
            command[2, 0] = Command.dog[2, 0];
            command[2, 1] = Command.dog[2, 1];
            command[2, 2] = Command.dog[2, 2];
            command[2, 0] = Command.dog[3, 0];
            command[2, 1] = Command.dog[3, 1];
        }
        else if (name == "cat")
        {
            command[0, 0] = Command.cat[0, 0];
            command[0, 1] = Command.cat[0, 1];
            command[0, 2] = Command.cat[0, 2];
            command[1, 0] = Command.cat[1, 0];
            command[1, 1] = Command.cat[1, 1];
            command[1, 2] = Command.cat[1, 2];
            command[2, 0] = Command.cat[2, 0];
            command[2, 1] = Command.cat[2, 1];
            command[2, 2] = Command.cat[2, 2];
            command[2, 0] = Command.cat[3, 0];
            command[2, 1] = Command.cat[3, 1];
        }
    }

    // 여기서부터 공격 조건 ----------------------------------------------------------------------------------

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

    IEnumerator EnemyHPMoreThanHalfAttack()  // 상대 체력 절반 이상일 때 공격
    {
        var enemyhp = akcoll.GetComponent<DefaultMove>();
        if (enemyhp.hp >= (enemyhp.fullhp / 2))
        {

            nav.speed = 0;
            transform.LookAt(akcoll.transform);
            Debug.Log("Enemy HP more than half attack");
            checkattackcommand = false;
            yield return new WaitForSeconds(1.5f);
        }
    }


    IEnumerator EnemyHPLessThanHalfAttack()  // 상대 체력 절반 미만일 때 공격
    {
        var enemyhp = akcoll.GetComponent<DefaultMove>();
        if (enemyhp.hp < (enemyhp.fullhp / 2))
        {

            nav.speed = 0;
            transform.LookAt(akcoll.transform);
            Debug.Log("Enemy HP less than half attack");
            checkattackcommand = false;
            yield return new WaitForSeconds(1.5f);
        }
    }

    IEnumerator MyHPIsMoreAttack()  // 내 체력이 더 많을 때 공격
    {
        var enemyhp = akcoll.GetComponent<DefaultMove>();
        if (enemyhp.hp < hp)
        {
            nav.speed = 0;
            transform.LookAt(akcoll.transform);
            Debug.Log("My HP is more than enemy's HP Attack");
            checkattackcommand = false;
            yield return new WaitForSeconds(1.5f);
        }
        yield return null;
    }

    IEnumerator OurTileIsMoreAttack()   // 땅이 더 많을 때 공격
    {
        if (tag == "redcharacter")
        {
            if (Command.redtile > Command.bluetile)
            {
                nav.speed = 0;   // 멈추고
                transform.LookAt(akcoll.transform);  //적 바라봄
                Debug.Log("Our tile is more than enemy's tile Attack");  // 공격
                checkattackcommand = false;
                yield return new WaitForSeconds(1.5f);
            }
        }
        else if (tag == "bluecharacter")
        {
            if (Command.bluetile > Command.redtile)
            {
                nav.speed = 0;
                transform.LookAt(akcoll.transform);
                Debug.Log("My tile is more than enemy's tile Attack");
                checkattackcommand = false;
                yield return new WaitForSeconds(1.5f);
            }
        }
        yield return null;
    }

    IEnumerator OurTileIsLessAttack()
    {
        if (tag == "redcharacter")
        {
            if (Command.redtile < Command.bluetile)
            {
                nav.speed = 0;   // 멈추고
                transform.LookAt(akcoll.transform);  //적 바라봄
                Debug.Log("Our tile is less than enemy's tile Attack");  // 공격
                checkattackcommand = false;
                yield return new WaitForSeconds(1.5f);
            }
        }
        else if (tag == "bluecharacter")
        {
            if (Command.bluetile < Command.redtile)
            {
                nav.speed = 0;
                transform.LookAt(akcoll.transform);
                Debug.Log("My tile is less than enemy's tile Attack");
                checkattackcommand = false;
                yield return new WaitForSeconds(1.5f);
            }
        }
        yield return null;
    }

    IEnumerator NoEmptyTileAttack()   // 빈 땅이 없을 때 공격
    {

        if ((Command.redtile + Command.bluetile) >= num_of_tile)
        {
            nav.speed = 0;   // 멈추고
            transform.LookAt(akcoll.transform);  //적 바라봄
            Debug.Log("There are no empty tile Attack");  // 공격
            checkattackcommand = false;
            yield return new WaitForSeconds(1.5f);
        }
    }

    // 여기까지 공격 조건 --------------------------------------------------------------------------------------


    // 여기서부터 이동 조건 -----------------------------------------------------------------------------------

    void Always()
    {
        // Debug.Log("Always");

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
            //  Debug.Log("HPMoreThanHalf");
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
            //  Debug.Log("HPLessThanHalf");
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
                    //   Debug.Log("Enemy is in Near");
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
                    //   Debug.Log("No Enemys in Near");
                    //i = -1;

                }
                i = -1;
            }
        }
    }

    void OurTileIsMore()  //땅이 더 많을 때
    {


        if (tag == "redcharacter")
        {
            if (Command.redtile > Command.bluetile)
            {
                //  Debug.Log("OurTileIsMore");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
                    i = -1;
                }
            }
        }
        else if (tag == "bluecharacter")
        {
            if (Command.bluetile > Command.redtile)
            {
                //  Debug.Log("OurTileIsMore");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
                    i = -1;
                }
            }
        }
        return;
    }

    void OurTileIsLess()  //땅이 더 적을 때
    {


        if (tag == "redcharacter")
        {
            if (Command.redtile < Command.bluetile)
            {
                Debug.Log("레드땅이 더 적음");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
                    i = -1;
                }
            }
        }
        else if (tag == "bluecharacter")
        {
            if (Command.bluetile < Command.redtile)
            {
                //  Debug.Log("OurTileIsMoreLess");
                checkcommand = false;  //조건이 맞았으므로 checkcommand를 false로 바꿔서 CheckCommand() 코루틴의 반복문을 중단시켜준다.


                if (runningact != command[i, 1])  //현재 실행 중인 행동과 command[i,1]에 있는 (지금 실행해야 할) 행동이 다른 경우에만 동작
                {
                    StopCoroutine(runningact);  //현재 실행 중인 행동 코루틴 종료
                    StartCoroutine(command[i, 1]);  //지금 실행해야 할 행동 시작
                    i = -1;
                }
            }
        }
        return;
    }



    void NoEmptyTile()  // 빈 땅이 없을 때
    {
        if ((Command.redtile + Command.bluetile) >= num_of_tile)
        {
            //  Debug.Log("OurTileIsLess");
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
    // 여기까지 이동 조건 -----------------------------------------------------------------------------------------



    // 여기서부터 이동 행동 ----------------------------------------------------------------------------------------

    IEnumerator JustWalk()
    {
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


    IEnumerator ChaseClosestAlly()
    {


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
        runningact = "GoToEnemyTile";
        bool gototile = false;
        //Debug.Log("Going to enemy tile");
        if (tag == "bluecharacter")
        {
            while (true)
            {
                yield return null;
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
        runningact = "GoToEmtyTile";
        bool gototile = false;
        //Debug.Log("Going to enemy tile");

        while (true)
        {
            yield return null;
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
}
