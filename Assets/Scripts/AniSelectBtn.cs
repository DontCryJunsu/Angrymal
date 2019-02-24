using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniSelectBtn : MonoBehaviour
{
    public GameObject[] Ani;
    public void pigBtn()
    {
        AllDown();
        Ani[0].SetActive(true);
    }
    public void mouseBtn()
    {
        AllDown();
        Ani[1].SetActive(true);
    }
    public void sheepBtn()
    {
        AllDown();
        Ani[2].SetActive(true);
    }
    public void snakeBtn()
    {
        AllDown();
        Ani[3].SetActive(true);
    }
    public void wolfBtn()
    {
        AllDown();
        Ani[4].SetActive(true);
    }
    public void KangarooBtn()
    {
        AllDown();
        Ani[5].SetActive(true);
    }
    public void jiraffeBtn()
    {
        AllDown();
        Ani[6].SetActive(true);
    }
    public void buffaloBtn()
    {
        AllDown();
        Ani[7].SetActive(true);
    }
    public void lionBtn()
    {
        AllDown();
        Ani[8].SetActive(true);
    }
    public void elephantBtn()
    {
        AllDown();
        Ani[9].SetActive(true);
    }
    public void AllDown()
    {
        for(int i=0;i<10;i++)
        {
            Ani[i].SetActive(false);
        }
    }
}
