using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteBtn : MonoBehaviour
{
    public void Xbtn()
    {
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "A", "0");
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "B", "0");
        PlayerPrefs.SetString(LobbyManager.aniNum + LobbyManager.cNum + "C", "0");
        GameObject.Find(LobbyManager.aniNum + LobbyManager.cNum).GetComponent<Text1>().SelectCmd();
    }
}
