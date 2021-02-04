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

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        int spawnPoint =  Random.Range(0, GameSetup.GS.spawnPoints.Length);
        if (PV.IsMine)
        {
            myAvatar = PhotonNetwork.Instantiate("PlayerAvatar",
               photonNetworkPlayer.transform.position, GameSetup.GS.spawnPoints[spawnPoint].rotation, 0);
            ((MonoBehaviour)myAvatar.GetComponent("AttackController")).enabled = true;
            ((MonoBehaviour)myAvatar.GetComponent("player_movement")).enabled = true;
            myAvatar.transform.Find("Camera").gameObject.AddComponent<Camera>();
            myAvatar.transform.Find("Camera").gameObject.transform.localPosition= new Vector3(0,1.58f,-4.29f);
            myAvatar.transform.Find("Camera").gameObject.transform.localRotation = new Quaternion(0.1f,0,0,1);




        }
        
    }
}
