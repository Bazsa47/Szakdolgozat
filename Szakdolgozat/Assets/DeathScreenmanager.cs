using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DeathScreenmanager : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        PhotonNetwork.LoadLevel("Rooms");
    }

    public void Retry()
    {
        if (PhotonNetwork.LocalPlayer.IsMasterClient)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.LoadLevel("Arena");
        }
    }
}
