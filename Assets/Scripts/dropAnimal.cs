﻿using System.Collections;
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
        if (cat2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (cat2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (cat2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        cat2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        cat2.transform.position = new Vector3(-120f, -112f, 0f);
        cat.GetComponent<LobbyCam>().act = true;
    }
    public void DG()
    {
        dog.SetActive(true);
        if (dog2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (dog2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (dog2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        dog2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        dog2.transform.position = new Vector3(-120f, -112f, 0f);
        dog.GetComponent<LobbyCam>().act = true;
    }
    public void BFL()
    {
        buffalo.SetActive(true);
        if (buffalo2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (buffalo2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (buffalo2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        buffalo2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        buffalo2.transform.position = new Vector3(-120f, -112f, 0f);
        buffalo.GetComponent<LobbyCam>().act = true;
    }
    public void JRF()
    {
        jiraffe.SetActive(true);
        if (jiraffe2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (jiraffe2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (jiraffe2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        jiraffe2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        jiraffe2.transform.position = new Vector3(-120f, -112f, 0f);
        jiraffe.GetComponent<LobbyCam>().act = true;
    }
    public void ELP()
    {
        elephant.SetActive(true);
        if (elephant2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (elephant2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (elephant2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        elephant2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        elephant2.transform.position = new Vector3(-120f, -112f, 0f);
        elephant.GetComponent<LobbyCam>().act = true;
    }
    public void WF()
    {
        wolf.SetActive(true);
        if (wolf2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (wolf2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (wolf2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        wolf2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        wolf2.transform.position = new Vector3(-120f, -112f, 0f);
        wolf.GetComponent<LobbyCam>().act = true;
    }
    public void SNK()
    {
        snake.SetActive(true);
        if (snake2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (snake2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (snake2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        snake2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        snake2.transform.position = new Vector3(-120f, -112f, 0f);
        snake.GetComponent<LobbyCam>().act = true;
    }
    public void SH()
    {
        sheep.SetActive(true);
        if (sheep2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (sheep2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (sheep2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        sheep2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        sheep2.transform.position = new Vector3(-120f, -112f, 0f);
        sheep.GetComponent<LobbyCam>().act = true;
    }
    public void KG()
    {
        kangaroo.SetActive(true);
        if (kangaroo2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (kangaroo2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (kangaroo2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        kangaroo2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        kangaroo2.transform.position = new Vector3(-120f, -112f, 0f);
        kangaroo.GetComponent<LobbyCam>().act = true;
    }
    public void LN()
    {
        lion.SetActive(true);
        if (lion2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (lion2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (lion2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        lion2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        lion2.transform.position = new Vector3(-120f, -112f, 0f);
        lion.GetComponent<LobbyCam>().act = true;
    }
    public void MS()
    {
        mouse.SetActive(true);
        if (mouse2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (mouse2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (mouse2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        mouse2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        mouse2.transform.position = new Vector3(-120f, -112f, 0f);
        mouse.GetComponent<LobbyCam>().act = true;
    }
    public void PG()
    {
        pig.SetActive(true);
        if (pig2.transform.position.x == 520f)
        {
            Debug.Log("1");
            LoadAnimal.C1 = false;

        }
        else if (pig2.transform.position.x == 640f)
        {
            Debug.Log("2");
            LoadAnimal.C2 = false;
        }
        else if (pig2.transform.position.x == 760f)
        {
            Debug.Log("3");
            LoadAnimal.C3 = false;
        }
        LobbyManager.loadAni--;
        pig2.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
        pig2.transform.position = new Vector3(-120f, -112f, 0f);
        pig.GetComponent<LobbyCam>().act = true;
    }
}