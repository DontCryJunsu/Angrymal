using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindAnimal : MonoBehaviour {

    public GameObject chicken;
    public GameObject dog;
    public GameObject elephant;
    public GameObject cat;
    public GameObject buffalo;
    public GameObject jiraffe;
    public GameObject sheep;
    public GameObject wolf;
    public GameObject pig;
    public GameObject kangaroo;
    public GameObject snake;
    public GameObject lion;
    public GameObject mouse;

    void Start () {
		if(PlayerPrefs.GetString("C1").Equals("chickenUI"))
        {
            LoadAnimal.act = true;
            chicken.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("dogUI"))
        {
            LoadAnimal.act = true;
            dog.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("elephantUI"))
        {
            LoadAnimal.act = true;
            elephant.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("catUI"))
        {
            LoadAnimal.act = true;
            cat.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("buffaloUI"))
        {
            LoadAnimal.act = true;
            buffalo.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("jiraffeUI"))
        {
            LoadAnimal.act = true;
            jiraffe.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("sheepUI"))
        {
            LoadAnimal.act = true;
            sheep.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("wolfUI"))
        {
            LoadAnimal.act = true;
            wolf.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("pigUI"))
        {
            LoadAnimal.act = true;
            pig.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("kangarooUI"))
        {
            LoadAnimal.act = true;
            kangaroo.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("snakeUI"))
        {
            LoadAnimal.act = true;
            snake.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("lionUI"))
        {
            LoadAnimal.act = true;
            lion.transform.position = gameObject.transform.position;
        }
        else if (PlayerPrefs.GetString("C1").Equals("mouseUI"))
        {
            LoadAnimal.act = true;
            mouse.transform.position = gameObject.transform.position;
        }
    }

}
