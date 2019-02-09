using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TARGET
{
    MASTER = 0,
    CLIENT = 1,
}

public class Attack : MonoBehaviour
{
     

    void OnTriggerEnter(Collider other)
    {
        if (tag == "redattack")
        {
            if (other.tag == "bluecharacter")
            {
                NetAttackDamage(other, gameObject.transform.parent.GetComponent<DefaultMove>().power);
            }
        }
        else if (tag == "blueattack")
        {
            if (other.tag == "redcharacter")
            {
                NetAttackDamage(other, gameObject.transform.parent.GetComponent<DefaultMove>().power);
            }
        }

    }




    public void NetAttackDamage(Collider col, float damage)
    {
        // 공격시의 데미지를 상대에게 전달함.
        int attackTarget = 0;

        if (PhotonNetwork.isMasterClient)
        {
            attackTarget = (int)TARGET.CLIENT;
            // 공격하는 대상이 방원일 때
        }
        else
        {
            attackTarget = (int)TARGET.MASTER;
            // 공격하는 대상이 방장일 때
        }
        //col.gameObject.GetComponent<DefaultMove>().AttackInfo(attackTarget,damage);
        //col.gameObject.GetComponent<PhotonView>().RPC("PreventDoubleAttack", PhotonTargets.Others, Time.deltaTime);
        col.gameObject.GetComponent<PhotonView>().RPC("AttackInfo", PhotonTargets.Others, attackTarget, damage);

        // AttackInfo 는  함수이름입니다.
        //PhotonTargets.Others 자신을 제외한 다른 유저에게 정보를 전송합니다.damage 는 전달하려고 하는 값입니다.
    }




}
