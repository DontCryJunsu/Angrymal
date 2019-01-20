using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testrandommove : MonoBehaviour
{
    public float speed = 2f;
    public GameObject[] obj;
    public NavMeshAgent nav;
    LobbyCam LC;
    public float sec = 3f;

    public void Stst()
    {
        LC = GetComponentInChildren<LobbyCam>();
        StartCoroutine("stst");
    }

    IEnumerator stst() {
        while (LC.act==true)
        {
            int i = 0;
            i = Random.Range(0, 8);
            nav = GetComponent<NavMeshAgent>();
            nav.SetDestination(obj[i].transform.position);
            yield return new WaitForSeconds(sec);
        }
    }
}
