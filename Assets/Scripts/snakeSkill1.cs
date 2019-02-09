using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeSkill1 : MonoBehaviour
{
    public GameObject part;
    bool isPoision = false;
    DefaultMove DM;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3.8f);
            part.SetActive(false);
            isPoision = false;
            yield return new WaitForSeconds(1.5f);
            part.SetActive(true);
            isPoision = true;
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "redcharacter" && isPoision)
        {
            other.gameObject.GetComponent<PhotonView>().RPC("Poison", PhotonTargets.Others);
        }
    }
}
