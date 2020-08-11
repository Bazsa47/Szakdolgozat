using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayers : MonoBehaviour
{

    void Awake() 
    {
        PhotonNetwork.Instantiate("PhotonNetworkPlayer",transform.position,Quaternion.identity,0);
    }
}
