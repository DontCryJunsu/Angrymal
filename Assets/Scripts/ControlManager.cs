using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
     public GameObject controlobject;  //각자 동물들의 Control 스크립트에서 조정됨
    public bool controlisenable = false;  //각자 동물들의 Control 스크립트에서 조정됨
    void Awake()
    {
       //StartCoroutine(ControlCoroutine());
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0) && controlisenable == true && controlobject != null)
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit)  )
            {
                if (hit.collider.tag == "Untagged" || hit.collider.tag == "redteam" || hit.collider.tag == "blueteam")
                {
                    controlobject.GetComponent<DefaultMove>().StopCoroutine("CheckCommand"); //CheckCommand 멈춤
                    controlobject.GetComponent<DefaultMove>().StopCoroutine(controlobject.GetComponent<DefaultMove>().runningact); //runningact 멈춤
                    controlobject.GetComponent<DefaultMove>().nav.destination = hit.point; //목표지점 변경
                    controlobject.GetComponent<Control>().vec3 = hit.point;
                    controlobject.GetComponent<Control>().StartCoroutine("UntilArrive");

                    controlisenable = false;
                    controlobject = null;
                }
            }
            
        }

    }

    IEnumerator ControlCoroutine()
    {
        while(true)
        {
            yield return null;
            if (controlisenable == true && controlobject != null)
            {
                yield return new WaitForSeconds(0.3f);
                
                while (controlisenable == true && controlobject != null)
                {
                    yield return null;
                    if (Input.GetMouseButtonDown(0))
                    {
                        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;

                        controlisenable = false;
                        controlobject = null;

                        if (Physics.Raycast(ray, out hit))
                        {
                            //동물 디폴트무브에 bool 변수 controling 넣고 조절할 것!
                            controlobject.GetComponent<DefaultMove>().StopCoroutine(controlobject.GetComponent<DefaultMove>().runningact); //runningact 멈춤
                            controlobject.GetComponent<DefaultMove>().StopCoroutine("CheckCommand"); //CheckCommand 멈춤
                            controlobject.GetComponent<DefaultMove>().nav.destination = hit.point; //클릭한 지점으로 이동시킴
                        }
                        break;
                    }
                }
            }
        }
    }

   
    void success()
    {

    }
}
