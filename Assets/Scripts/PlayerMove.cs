using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    int[,] Animal = new int[7, 10];
    int x, y;
    float Move_Delay = 0.0f;
    float speed=10;
    float Move_Max=0;
    // Use this for initialization
    void Start()
    {
        x = 3;
        y = 2;
        Animal[x, y] = 1;
        StartCoroutine("move");
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("x" + x);
        Debug.Log("y" + y);
        MapArray.Map[x, y] = 1;
    }

    IEnumerator move()
    {
        while (true)
        {
            Move_Max = 0;
            yield return new WaitForSeconds(Move_Delay); // 이동시 딜레이
            if (MapArray.Map[x + 1, y] == 0) //오른쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
                x++;
                
                while (Move_Max < 5) { 
                    transform.position += (new Vector3(0.01f*speed, 0, 0));   
                    Move_Max += (0.01f * speed);
                    yield return new WaitForSeconds(0.01f);
                }
                /*  //speed 없는 버전
               for (int i = 0; i < 20; i++)
               {
                   transform.Translate(new Vector3(0.25f, 0, 0), Space.World);
                   yield return new WaitForSeconds(0.01f);
               }
               */


            }
            else if (MapArray.Map[x - 1, y] == 0) //왼쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back);
                x--;
                while (Move_Max < 5)
                {
                    transform.position += (new Vector3(-0.01f * speed, 0, 0));   
                    Move_Max += (0.01f * speed);
                    yield return new WaitForSeconds(0.01f);
                }
                /*
                for (int i = 0; i < 20; i++)
                {
                    transform.Translate(new Vector3(-0.25f, 0, 0), Space.World);
                    yield return new WaitForSeconds(0.01f);
                }
                */
            }
            else if (MapArray.Map[x, y + 1] == 0) //위쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.left);
                y++;
                while (Move_Max < 5)
                {
                    transform.position += (new Vector3(0, 0, 0.01f * speed));
                    Move_Max += (0.01f * speed);
                    yield return new WaitForSeconds(0.01f);
                }
                /*
                for (int i = 0; i < 20; i++)
                {
                    transform.Translate(new Vector3(0, 0, 0.25f), Space.World);
                    yield return new WaitForSeconds(0.01f);
                }
                */
            }
            else if (MapArray.Map[x, y - 1] == 0) //아래쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.right);
                y--;
                while (Move_Max < 5)
                {
                    transform.position += (new Vector3(0, 0, -0.01f * speed));
                    Move_Max += (0.01f * speed);
                    yield return new WaitForSeconds(0.01f);
                }
                /*
                for (int i = 0; i < 20; i++)
                {
                    transform.Translate(new Vector3(0, 0, -0.25f), Space.World);
                    yield return new WaitForSeconds(0.01f);
                }
                */
            }
        }


    }
}
