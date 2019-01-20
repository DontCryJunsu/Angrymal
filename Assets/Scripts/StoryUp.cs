using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryUp : MonoBehaviour
{
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        float yMove = 50 * Time.deltaTime; //y축으로 이동할양 
        this.transform.Translate(new Vector3(0, yMove, 0));  //이동
    }
}
