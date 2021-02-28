using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeathScreenmanager : MonoBehaviour
{
    public PhotonView pv;
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        if(PhotonNetwork.InLobby) PhotonNetwork.LeaveLobby();
        if(PhotonNetwork.InRoom) PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("Rooms");
    }

    public void Retry()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient) { 

            PhotonNetwork.AutomaticallySyncScene = true;
           pv.RPC("RetryRPC",RpcTarget.All);
           
        }
    }

    [PunRPC]
    public void RetryRPC()
    {
        PhotonNetwork.LoadLevel("Arena");
    }
}
