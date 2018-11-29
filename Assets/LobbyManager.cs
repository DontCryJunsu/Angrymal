using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LobbyManager : MonoBehaviour
{   
    //1.고양이 2.병아리 3.물소 4.닭 5.개 6.코끼리 7.기린 8.캥거루 9.사자 10.쥐 11.돼지 12.양 13.뱀 14.늑대
    public static int aniNum = 0;
    public static bool esc = false;
    public GameObject ship;

    public void ESC()
    {
        esc = true;
    }
    
    public void StartBtn()
    {
        ship.GetComponent<Animator>().enabled = true;
    }
}
