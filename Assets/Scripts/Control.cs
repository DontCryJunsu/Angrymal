using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public bool controling = false;
    public Vector3 vec3;
    public GameObject Star;

    void OnMouseDown()
    {
        if (PhotonNetwork.isMasterClient)
        {
            if (tag == "redcharacter" && controling == false && Camera.main.GetComponent<ControlManager>().controlisenable == false)
            {   
                Star.SetActive(true);
                Star.GetComponent<AnimationScript>().setYellow();
                StartCoroutine("ControlTime");
                controling = true; //컨트롤 시작
            }
        }
        else
        {
            if (tag == "bluecharacter" && controling == false && Camera.main.GetComponent<ControlManager>().controlisenable == false)
            {
                Star.SetActive(true);
                Star.GetComponent<AnimationScript>().setYellow();
                StartCoroutine("ControlTime");
                controling = true;
            }
        }
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;
        //if (Physics.Raycast(ray, out hit))
        //{
        //    Debug.Log(hit.transform.name);
        //    Camera.main.GetComponent<ControlManager>().controlobject = hit.collider.gameObject;  //카메라에 있는 변수들 조정
        //    Camera.main.GetComponent<ControlManager>().controlisenable = true;  //카메라에 있는 변수들 조정
            

        //}
    }

    IEnumerator ControlTime()
    {
        Debug.Log("눌러졌습니다!!!!!!!!!");
         
        yield return new WaitForSeconds(0.3f);
         
  
        Camera.main.GetComponent<ControlManager>().controlobject = this.gameObject;  //카메라에 있는 변수들 조정
   
        Camera.main.GetComponent<ControlManager>().controlisenable = true;  //카메라에 있는 변수들 조정
         
    }

    IEnumerator UntilArrive()  //컨트롤 목표 지점에 도착했을때 컨트롤 끝나게 해줌
    {
        controling = true;
        Star.GetComponent<AnimationScript>().setCyan();
        while (controling == true)
        {
            yield return null;
            if (Vector3.Distance(vec3, this.transform.position) <= 2)
            {
                controling = false;
                GetComponent<DefaultMove>().StartCoroutine(GetComponent<DefaultMove>().runningact); //runningact 멈춤
                GetComponent<DefaultMove>().StartCoroutine("CheckCommand"); //CheckCommand 멈춤
                Star.SetActive(false);
            }
        }
    }

    
}
