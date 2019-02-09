using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeSkill1 : MonoBehaviour
{
    bool isSkill = false;
    public Material snakeMat;
    public Material palete;
    public Renderer snakeRen;
    bool isPoision = false;
    DefaultMove DM;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            snakeRen.sharedMaterial = palete;
            isPoision = false;
            yield return new WaitForSeconds(3f);
            snakeRen.sharedMaterial = snakeMat;
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
