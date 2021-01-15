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
        int spawnPoint = Random.Range(0, GameSetup.GS.spawnPoints.Length);
            PhotonNetwork.Instantiate("PhotonNetworkPlayer", GameSetup.GS.spawnPoints[0].position, GameSetup.GS.spawnPoints[0].rotation, 0);
    }
}
