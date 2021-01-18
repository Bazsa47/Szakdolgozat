using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PhotonPlayer : MonoBehaviour
{
    private PhotonView PV;
    public GameObject myAvatar;
    public GameObject photonNetworkPlayer;

    void Start()
    {
        PV = GetComponent<PhotonView>();
        int spawnPoint =  Random.Range(0, GameSetup.GS.spawnPoints.Length);
        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate("PlayerAvatar",
               photonNetworkPlayer.transform.position, GameSetup.GS.spawnPoints[spawnPoint].rotation, 0);
        }
    }
}
