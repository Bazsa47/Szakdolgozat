﻿using Photon.Pun;
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
        int index = 0;
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            if (PhotonNetwork.PlayerList[i].IsLocal)
            {
                index = i;
                break;
            }
        }
        PhotonNetwork.Instantiate("PhotonNetworkPlayer", GameSetup.GS.spawnPoints[index].position, GameSetup.GS.spawnPoints[spawnPoint].rotation, 0);

        PhotonNetwork.InstantiateSceneObject("Enemy", new Vector3(-6f, 1.831805f, -6.2f), GameSetup.GS.spawnPoints[spawnPoint].rotation, 0);
        PhotonNetwork.InstantiateSceneObject("Enemy", new Vector3(-1f, 1.831805f, -6.2f), GameSetup.GS.spawnPoints[spawnPoint].rotation, 0);
        PhotonNetwork.InstantiateSceneObject("Enemy", new Vector3(4f, 1.831805f, -6.2f), GameSetup.GS.spawnPoints[spawnPoint].rotation, 0);
        PhotonNetwork.InstantiateSceneObject("Enemy", new Vector3(9f, 1.831805f, -6.2f), GameSetup.GS.spawnPoints[spawnPoint].rotation, 0);
    }
}
