
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Reflection;

public class AlwaysAtk : MonoBehaviour
{
    NavMeshAgent nav;
    bool checkattackcommand = true;
    Collider akcoll = null;
    private float angularbuffer; //공격에서 사용하는 회전속도
    public AudioSource AS; //공격 소리

    float time = -0.1f; //PreventDoubleAttack 함수에서 사용
    float comparetime = 1.0f;

    private int ckani;

    Vector3 destination; //현재 동물이 목표로 하는 곳

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();

        if (name != "babychicken")
            StartCoroutine(CheckAttackCommand());
    }


    IEnumerator CheckAttackCommand()  // 공격 명령 기본 틀
    {


        while (checkattackcommand == true)   // <명령어 줄이기> while(true)
        {

            ckani = 0; //애니메이터 변수 초기화

            yield return null;

            if (tag == "redcharacter")
            {
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 2.5f);

                foreach (Collider coll in colls)
                {
                    yield return null; //렉 걸리는지 확인 중
                    if (coll != null)
                    {
                        if (coll.gameObject.tag == "bluecharacter")
                        {
                      
                            yield return null;
                    
                            akcoll = coll;
                         
                            yield return StartCoroutine("AlwaysAttack");
                           // nav.speed = GetComponent<DefaultMove>().speed;
                     
                        }
                    }
                }

            }
            else if (tag == "bluecharacter")
            {
                Collider[] colls = Physics.OverlapSphere(this.transform.position, 2.5f);
                foreach (Collider coll in colls)
                {
                    yield return null; //렉 걸리는지 확인 중
                    if (coll != null)
                    {
                        if (coll.gameObject.tag == "redcharacter")
                        {
                         
                            yield return null;
          
                            akcoll = coll;
          
                            yield return StartCoroutine("AlwaysAttack");
                          //  nav.speed = GetComponent<DefaultMove>().speed;
                           
                        }
                    }
                }
            }

        }
    }

    IEnumerator AlwaysAttack()
    {
        //애니메이터
        ckani = 1;
        GetComponent<DefaultMove>().animation.SetInteger("ckani", ckani);

        ///destinationbuffer = nav.destination;  //공격 끝나면 목표지점 돌려놓으려고 목표지점 저장해놓음

        //nav.speed = 0;  // 멈춰 선다.  -------------test
        nav.Stop();
        //destination = nav.destination;

        transform.LookAt(akcoll.transform);  // 공격할 상대를 바라봄
        //angularbuffer = nav.angularSpeed;    ------test
        //nav.angularSpeed = 0;  -------------------test


        Debug.Log("항상공격");
        //isAttack = true;
        // animation.SetBool("isAttack", isAttack); //애니메이션세팅
        ckani = 1;
        GetComponent<DefaultMove>().animation.SetInteger("ckani", ckani);

       // nav.speed = 0;  // 멈춰 선다. ---test
      //  transform.LookAt(akcoll.transform);  // 공격할 상대를 바라봄  ----test


        akcoll.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.All, Time.deltaTime);
        transform.GetChild(1).gameObject.SetActive(true);  //공격 
        yield return null;
        //NetAttackDamage(power)destination;
         


        //checkattackcommand = false; //<명령어 줄이기>
        yield return new WaitForSeconds(0.5f);
        transform.GetChild(1).gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        //nav.angularSpeed = angularbuffer;  //회전속도 돌려놓음  ---test
        nav.Resume();
                                           // nav.SetDestination(destinationbuffer); //navmesh 목표지점 원래대로 돌려놈

    }


    [PunRPC]
    public void AttackInfo(int attackTarget, float damage)
    {
        if (GetComponent<DefaultMove>().hp > 0)
        {
            AttackProcess(attackTarget, damage);
        }
        // pv.RPC("AttackProcess", PhotonTargets.All, attackTarget, damage);
    }


    public void AttackProcess(int attackTarget, float damage)
    {
        if (time != comparetime)
        {
            GetComponent<PhotonView>().RPC("AttackSound", PhotonTargets.All); //맞을때 나는 소리
            GetComponent<DefaultMove>().hp -= damage;
            time = comparetime;

            if (transform.name == "mouse")
            {
                GetComponent<PhotonView>().RPC("MouseSkill", PhotonTargets.All);
            }
            if (transform.name == "wolf")
            {
                GetComponent<PhotonView>().RPC("WolfSkill", PhotonTargets.All);
            }
            if (transform.name == "buffalo")
            {
                GetComponent<PhotonView>().RPC("BuffaloSkill", PhotonTargets.All);
            }
            if (transform.name == "elephant")
            {
                GetComponent<PhotonView>().RPC("ElephantSkill", PhotonTargets.All);
            }
            ckani = 2;
            GetComponent<DefaultMove>().animation.SetInteger("ckani", ckani);
        }

    }
    [PunRPC]
    public void PreventDoubleAttack(float pda)
    {
        comparetime = pda;
    }

    [PunRPC]
    public void AttackSound()
    {
        AS.Play();
    }

    [PunRPC]
    public void MouseSkill()
    {
        GetComponent<mouseSkill>().skill();
    }

    [PunRPC]
    public void WolfSkill()
    {
        GetComponent<wolfSkill>().skill();
    }

    [PunRPC]
    public void BuffaloSkill()
    {
        GetComponent<buffaloSkill>().skill();
    }

    [PunRPC]
    public void ElephantSkill()
    {
        GetComponent<elephantSkill>().skill();
    }

}
