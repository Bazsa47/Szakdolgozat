﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemySlain : MonoBehaviour, IPunOwnershipCallbacks
{

    public Enemy enemy;
    public PhotonView pv;

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {
        PhotonNetwork.Destroy(targetView.gameObject);
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        PhotonNetwork.Destroy(targetView.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            if (!pv.IsMine)
            {
                pv.RequestOwnership();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            int newHp = enemy.hp - 35;
            pv.RPC("DmgEnemy", RpcTarget.All, newHp);
           

        }
    }

    [PunRPC]
    public void DmgEnemy(int newHp)
    {
        enemy.hp = newHp;
        if (enemy.hp <= 0)
            PhotonNetwork.Destroy(this.gameObject);
    }

}
