using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class CreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI roomName;

    private RoomsCanvases roomsCanvases;
    public void FirstInitialize(RoomsCanvases canvases)
    {
        roomsCanvases = canvases;
    }
    public void OnClick_CreateRoom()
    {
        if (!PhotonNetwork.IsConnected) return;
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName.text ,options,TypedLobby.Default);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Created room successfully");
        roomsCanvases.CurrentRoomCanvas.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room Creation Failed");  
    }

}
