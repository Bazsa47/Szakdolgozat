using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Nexus : MonoBehaviour
{
    [SerializeField]
    private float hp;

    public void TakeDmg(float dmg)
    {
        float newhp = hp - dmg;
        if(hp <=0)
        {
            GetComponent<PhotonView>().RPC("GameOver", RpcTarget.All);
        }
        else
        {
            GetComponent<PhotonView>().RPC("TakeNexusDmgRPC", RpcTarget.All, newhp, GetComponent<PhotonView>().ViewID);
        }
    }

    [PunRPC]
    public void TakeNexusDmgRPC(float newhp, int viewId)
    {
        PhotonView.Find(viewId).GetComponent<Nexus>().hp = newhp;
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int j = 1; j <= players.Length; j++)
        {
            Slider s = players[j - 1].gameObject.transform.Find("Camera").transform.Find("Canvas").transform.Find("UI").transform.Find("NexusHpBar").GetComponent<Slider>();
            if (s != null)
            {
                s.value = newhp;
            }
        }
    }

    [PunRPC]
    public void GameOver()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GetComponent<PhotonView>().RPC("DieRpc", RpcTarget.All);
        }
    }

}
