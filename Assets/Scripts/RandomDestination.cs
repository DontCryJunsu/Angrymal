using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestination : MonoBehaviour
{

    //public GameObject chase;
    public string chaser;
    //GameObject[] tile;
    public Transform[] tile2;
    void Start()
    {
        //tile = new GameObject[277];
        //tile2 = new Transform[277];
        //for(int i=1;i<=276;i++)
        //{
        //    tile[i] = GameObject.Find(i.ToString());
        //    tile2[i] = tile[i].transform;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        int rand = Random.RandomRange(1, 276);
        if (other.name == chaser)
        {
            //  UnityEngine.Debug.Log("goal");
            Debug.Log(rand);
           // transform.position = new Vector3(tile2[rand].position.x, tile2[rand].position.y+0.4f, tile2[rand].position.z);

        }




    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == chaser || other.tag == "wall")
        {
            // UnityEngine.Debug.Log("goal");

            transform.position = new Vector3(Random.Range(-19, 19), 5, Random.Range(-30, 30));


        }




    }
}
