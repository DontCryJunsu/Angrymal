using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFootBlue : MonoBehaviour
{

    public Transform baseDot; // 자신팀 발자국(블루)
    bool check = true; // 발자국 닿았는지 체크
    float coolTime;
    // 닿는 발자국 팀별로 체크
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "blueteam")
        {
            check = false;
        }
        if (other.tag == "redteam")
        {
            other.gameObject.tag = "blueteam";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "blueteam")
        {
            check = true;
        }
    }

    void FixedUpdate()
    {
        coolTime += Time.deltaTime;
        //Debug.Log(check);
        // check돼어있다면 발자국 생성
        Vector3 objPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        Quaternion objQuat = Quaternion.Euler(90f, 0, 0);
        if (check == true && coolTime > 0.75f) // 쿨타임 설정
        {
            Instantiate(baseDot, objPosition, objQuat);
            baseDot.transform.tag = "blueteam";
            coolTime = 0;
        }
    }
}
