using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapArray : MonoBehaviour
{
    public static int[,] Map = new int[7, 10];
    // Use this for initialization
    void Start()
    {
        Map[1, 3] = 1;
        Map[1, 4] = 1;
        Map[1, 5] = 1;
        Map[1, 6] = 1;
        Map[2, 4] = 1;
        Map[2, 5] = 1;
        Map[5, 3] = 1;
        Map[5, 4] = 1;
        Map[5, 5] = 1;
        Map[5, 6] = 1;
        for (int i = 0; i < 10; i++)
        {
            Map[0, i] = 1;
            Map[6, i] = 1;
        }
        for (int i = 0; i < 7; i++)
        {
            Map[i, 0] = 1;
            Map[i, 9] = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
