using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class LoadAnimal : MonoBehaviour {

    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public static bool C1 = false;
    public static bool C2 = false;
    public static bool C3 = false;
    GameObject animalUI;
    public static bool act = true;
    public GameObject X;

    public GameObject cat;
    public GameObject dog;
    public GameObject kangaroo;
    public GameObject lion;
    public GameObject wolf;
    public GameObject chicken;
    public GameObject buffalo;
    public GameObject mouse;
    public GameObject snake;
    public GameObject pig;
    public GameObject sheep;
    public GameObject elephant;
    public GameObject jiraffe;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource> ();
        GameObject temp;

        if (PlayerPrefs.GetString("C1", "1") != "1")
        {
            temp = GameObject.Find(PlayerPrefs.GetString("C1"));
            LobbyManager.loadAni++;
            LoadAnimal.C1 = true;
            aniaml(temp, c1);
            StartCoroutine(sizeUp(temp));
        }

        if (PlayerPrefs.GetString("C2", "1") != "1")
        {
            temp = GameObject.Find(PlayerPrefs.GetString("C2"));
            LobbyManager.loadAni++;
            LoadAnimal.C2 = true;
            aniaml(temp, c2);
            StartCoroutine(sizeUp(temp));
        }

        if (PlayerPrefs.GetString("C3", "1") != "1")
        {
            temp = GameObject.Find(PlayerPrefs.GetString("C3"));
            LobbyManager.loadAni++;
            LoadAnimal.C3 = true;
            aniaml(temp, c3);
            StartCoroutine(sizeUp(temp));
        }

        if (PlayerPrefs.GetString("C1").Equals("catUI") || PlayerPrefs.GetString("C2").Equals("catUI") || PlayerPrefs.GetString("C3").Equals("catUI"))
        {
            cat.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("dogUI") || PlayerPrefs.GetString("C2").Equals("dogUI") || PlayerPrefs.GetString("C3").Equals("dogUI"))
        {
            dog.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("kangarooUI") || PlayerPrefs.GetString("C2").Equals("kangarooUI") || PlayerPrefs.GetString("C3").Equals("kangarooUI"))
        {
            kangaroo.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("lionUI") || PlayerPrefs.GetString("C2").Equals("lionUI") || PlayerPrefs.GetString("C3").Equals("lionUI"))
        {
            lion.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("wolfUI") || PlayerPrefs.GetString("C2").Equals("wolfUI") || PlayerPrefs.GetString("C3").Equals("wolfUI"))
        {
            wolf.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("chickenUI") || PlayerPrefs.GetString("C2").Equals("chickenUI") || PlayerPrefs.GetString("C3").Equals("chickenUI"))
        {
            chicken.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("buffaloUI") || PlayerPrefs.GetString("C2").Equals("buffaloUI") || PlayerPrefs.GetString("C3").Equals("buffaloUI"))
        {
            buffalo.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("mouseUI") || PlayerPrefs.GetString("C2").Equals("mouseUI") || PlayerPrefs.GetString("C3").Equals("mouseUI"))
        {
            mouse.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("snakeUI") || PlayerPrefs.GetString("C2").Equals("snakeUI") || PlayerPrefs.GetString("C3").Equals("snakeUI"))
        {
            snake.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("pigUI") || PlayerPrefs.GetString("C2").Equals("pigUI") || PlayerPrefs.GetString("C3").Equals("pigUI"))
        {
            pig.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("sheepUI") || PlayerPrefs.GetString("C2").Equals("sheepUI") || PlayerPrefs.GetString("C3").Equals("sheepUI"))
        {
            sheep.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("elephantUI") || PlayerPrefs.GetString("C2").Equals("elephantUI") || PlayerPrefs.GetString("C3").Equals("elephantUI"))
        {
            elephant.SetActive(false);
        }
        if (PlayerPrefs.GetString("C1").Equals("jiraffeUI") || PlayerPrefs.GetString("C2").Equals("jiraffeUI") || PlayerPrefs.GetString("C3").Equals("jiraffeUI"))
        {
            jiraffe.SetActive(false);
        }
    }

    void Update () {
		if(C1 == true && C2==true && C3==true)
        {
            X.SetActive(false);
        }
        else
        {
            X.SetActive(true);
        }
	}
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "animal" && act == true)
        {
            Debug.Log("탔다!!");
            audioSource.Play();

            act = false;
            other.GetComponent<LobbyCam>().nav.enabled = false;
            string NAME = other.gameObject.name + "UI";
            other.gameObject.SetActive(false);
            other.GetComponentInParent<Transform>().transform.position = new Vector3(Random.Range(-20f, 40f), 7f, Random.Range(-60f, 40));
            animalUI = GameObject.Find(NAME);
            StartCoroutine(sizeUp(animalUI));
            if(C1 == false)
            {
                PlayerPrefs.SetString("C1", NAME);
                aniaml(animalUI, c1);
                C1 = true;
            }
            else if(C2 == false)
            {
                PlayerPrefs.SetString("C2", NAME);
                aniaml(animalUI, c2);
                C2 = true;
            }
            else if (C3 == false)
            {
                PlayerPrefs.SetString("C3", NAME);
                aniaml(animalUI, c3);
                C3 = true;
            }
        }
    }

    void aniaml(GameObject gm, GameObject target)
    {
        gm.transform.position = new Vector3(target.transform.position.x, target.transform.position.y - 34f, target.transform.position.z);
    }

    IEnumerator sizeUp(GameObject GM)
    {
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.02f);
            GM.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.01f);
            GM.transform.localScale += new Vector3(0.2f, 0.2f, 0);
        }
        for (int i = 0; i < 4; i++)
        {
            yield return new WaitForSeconds(0.02f);
            GM.transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        act = true;
        yield return null;
    }

}
