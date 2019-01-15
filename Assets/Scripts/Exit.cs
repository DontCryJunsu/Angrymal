using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject exitPan;
    bool isExit = true;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isExit)
        {
            exitPan.SetActive(true);
            isExit = false;
            //PhotonNetwork.LeaveRoom();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && !isExit)
        {
            exitPan.SetActive(false);
            isExit = true;
            //PhotonNetwork.LeaveRoom();
        }
    }

    public void xBtn()
    {
        if (isExit)
        {
            exitPan.SetActive(true);
            isExit = false;
        }
        else if (!isExit)
        {
            exitPan.SetActive(false);
            isExit = true;
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadSceneAsync("LobbyScene");
    }
}
