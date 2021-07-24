using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Network : MonoBehaviour
{
    bool isWaiting=true;
    [SerializeField]
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(null);
    }

    void OnJoinedLobby()
    {
        print("ロビー");
        PhotonNetwork.JoinRandomRoom();
    }

    void OnJoinedRoom()
    {
        print("ルームに入室");
    }

    void OnPhotonRandomJoinFailed()
    {
        print("失敗");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        PhotonNetwork.CreateRoom("",roomOptions,null);
        print("ルーム作成");
    }
    // Update is called once per frame
    void Update()
    {
        if (isWaiting)
        {
            if (PhotonNetwork.inRoom)
            {
                if (PhotonNetwork.room.playerCount == 2)
                {
                    PhotonNetwork.room.open = false;
                    isWaiting = false;
                    gameManager.SendMessage("GameStart");
                }
            }
        }
    }
}
