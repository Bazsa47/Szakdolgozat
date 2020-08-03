using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class RoomListing : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    public RoomInfo RoomInfo { get; private set; }


    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = roomInfo.Name + ", " + roomInfo.MaxPlayers;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(RoomInfo.Name);  
    }
}
