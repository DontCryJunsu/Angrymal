using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropAnimal : MonoBehaviour {
    public GameObject chicken;
    public GameObject cat;
    public GameObject dog;
    public GameObject buffalo;
    public GameObject jiraffe;
    public GameObject elephant;
    public GameObject wolf;
    public GameObject snake;
    public GameObject sheep;
    public GameObject kangaroo;
    public GameObject mouse;
    public GameObject lion;
    public GameObject pig;

    public GameObject chicken2;
    public GameObject cat2;
    public GameObject dog2;
    public GameObject buffalo2;
    public GameObject jiraffe2;
    public GameObject elephant2;
    public GameObject wolf2;
    public GameObject snake2;
    public GameObject sheep2;
    public GameObject kangaroo2;
    public GameObject mouse2;
    public GameObject lion2;
    public GameObject pig2;

    public void CK()
    {
        chicken.SetActive(true);
        if (chicken2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (chicken2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (chicken2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        chicken2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        chicken2.transform.position = new Vector3(-120f, -112f, 0f);
        chicken.GetComponent<LobbyCam>().act = true;
    }
    public void CT()
    {
        cat.SetActive(true);
    }
    public void DG()
    {
        dog.SetActive(true);
    }
    public void BFL()
    {
        buffalo.SetActive(true);
    }
    public void JRF()
    {
        jiraffe.SetActive(true);
    }
    public void ELP()
    {
        elephant.SetActive(true);
    }
    public void WF()
    {
        wolf.SetActive(true);
    }
    public void SNK()
    {
        snake.SetActive(true);
    }
    public void SH()
    {
        sheep.SetActive(true);
    }
    public void KG()
    {
        kangaroo.SetActive(true);
    }
    public void LN()
    {
        lion.SetActive(true);
    }
    public void MS()
    {
        mouse.SetActive(true);
    }
    public void PG()
    {
        pig.SetActive(true);
    }
}
