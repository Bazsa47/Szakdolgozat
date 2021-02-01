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
            myAvatar.transform.Find("Camera").gameObject.SetActive(true);
            myAvatar.transform.Find("CMFreeLook1").gameObject.SetActive(true);
            ((MonoBehaviour)myAvatar.GetComponent("AttackController")).enabled = true;
            ((MonoBehaviour)myAvatar.GetComponent("player_movement")).enabled = true;
        }
        
    }
}
