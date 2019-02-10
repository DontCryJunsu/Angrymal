using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public AudioSource AS;

    private void Start()
    {
         Invoke("Sound", 1f);
    }

    public void SceneChange()
    {
        Debug.Log("씬 체인지");
    }
    
    void Sound()
    {
        AS.Play();
    }
}
