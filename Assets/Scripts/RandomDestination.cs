using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDestination : MonoBehaviour
{

    //public GameObject chase;
    public string chaser;
    GameObject[] tile;
    public Transform[] tile2;
    int rand;

    void Start()
    {
        rand = Random.RandomRange(1, 275);
        tile = new GameObject[276];
        tile2 = new Transform[276];
        for (int i = 1; i <= 275; i++)
        {
            tile[i] = GameObject.Find(i.ToString());
            tile2[i] = tile[i].transform;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == chaser)
        {
            rand = Random.RandomRange(1, 275);
            transform.position = new Vector3(tile2[rand].position.x, tile2[rand].position.y + 1.3f, tile2[rand].position.z);

            //shuffle();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == chaser)
        {
            rand = Random.RandomRange(1, 275);
            transform.position = new Vector3(tile2[rand].position.x, tile2[rand].position.y + 1.3f, tile2[rand].position.z);

            //shuffle();
        }
        /*
        if (other.tag == chaser || other.tag == "wall")
        {
            // UnityEngine.Debug.Log("goal");

            transform.position = new Vector3(Random.Range(-19, 19), 5, Random.Range(-30, 30));
        }
        */
    }


    // 동물destination 게임오브젝트의 tag를 각팀 색깔로 지정해놓으면 이제 상대 또는 태그안달린곳으로 이동가능
    public void shuffle()
    {
        while (true)
        {
            if ((transform.tag == "bluedestination" && tile2[rand].tag == "Untagged")||(transform.tag == "bluedestination" && tile2[rand].tag == "blueteam"))
            {
                rand = Random.RandomRange(1, 275);
            }
            else if ((transform.tag == "reddestination" && tile2[rand].tag == "Untagged") || (transform.tag == "reddestination" && tile2[rand].tag == "redteam"))
            {
                rand = Random.RandomRange(1, 275);
            }
            else
            {
                break;
            }
        }
        transform.position = new Vector3(tile2[rand].position.x, tile2[rand].position.y + 1.3f, tile2[rand].position.z);
    }


    public void shuffleempty()
    {
        while (true)
        {
            if (tile2[rand].tag == "redteam" || tile2[rand].tag == "blueteam")
            {
                rand = Random.RandomRange(1, 275);
            }
            else
            {
                break;
            }
        }
        transform.position = new Vector3(tile2[rand].position.x, tile2[rand].position.y + 1.3f, tile2[rand].position.z);
    }
}
