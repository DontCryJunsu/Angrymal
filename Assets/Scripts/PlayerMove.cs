using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    int[,] Animal = new int[7, 10];
    int x, y;
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
            yield return new WaitForSeconds(0.5f); // 이동시 딜레이
            if (MapArray.Map[x + 1, y] == 0) //오른쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward);
                x++;
                for (int i = 0; i < 20; i++)
                {
                    transform.Translate(new Vector3(0.25f, 0, 0), Space.World);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else if (MapArray.Map[x - 1, y] == 0) //왼쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.back);
                x--;
                for (int i = 0; i < 20; i++)
                {
                    transform.Translate(new Vector3(-0.25f, 0, 0), Space.World);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else if (MapArray.Map[x, y + 1] == 0) //위쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.left);
                y++;
                for (int i = 0; i < 20; i++)
                {
                    transform.Translate(new Vector3(0, 0, 0.25f), Space.World);
                    yield return new WaitForSeconds(0.01f);
                }
            }
            else if (MapArray.Map[x, y - 1] == 0) //아래쪽
            {
                transform.rotation = Quaternion.LookRotation(Vector3.right);
                y--;
                for (int i = 0; i < 20; i++)
                {
                    transform.Translate(new Vector3(0, 0, -0.25f), Space.World);
                    yield return new WaitForSeconds(0.01f);
                }
            }
        }


    }
}
