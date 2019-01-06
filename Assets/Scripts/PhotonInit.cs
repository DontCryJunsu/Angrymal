using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonInit : MonoBehaviour {
    public string version = "v1.0";

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(version);
    }
    
    void OnJoinedLobby()
    {
        Debug.Log("Entered Lobby");
    }

    //private void OnGUI()
    //{
    //    GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    //}

    public void OnClickJoinRandomRoom()
    {
        //PlayerPrefs.SetString("USER_ID", "BLUE");
        PlayerPrefs.SetString("Team", "B");
        PhotonNetwork.player.name = PlayerPrefs.GetString("userName");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnJoinedRoom()
    {
        Debug.Log("Enter Room");
        StartCoroutine(this.LoadBattleScene());
    }

    public void OnClickCreatedRoom()
    {
        string _roomName = "ROOM_" + Random.Range(0, 999).ToString("000");

        //PlayerPrefs.SetString("USER_ID", "RED");
        PlayerPrefs.SetString("Team", "R");
        PhotonNetwork.player.name = PlayerPrefs.GetString("userName");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.isOpen = true;
        roomOptions.isVisible = true;
        roomOptions.maxPlayers = 2;

        //지정한 조건에 맞는 룸 생성 함수
        PhotonNetwork.CreateRoom(_roomName, roomOptions, TypedLobby.Default);
    }

    void OnPhotonRandomJoinFailed()
    {
        OnClickCreatedRoom();
    }

    IEnumerator LoadBattleScene()
    {
        PhotonNetwork.isMessageQueueRunning = false;
        yield return new WaitForSeconds(2f);
        AsyncOperation ao = SceneManager.LoadSceneAsync("BattleScene");
        yield return ao;
    }

    // 룸생성 실패
    void OnPhotonCreateRoomFailed(object[] codeAndMsg)
    {
        Debug.Log("방생성실패" + codeAndMsg[1]);
    }
}
