using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerClass : Entity
{
    [SerializeField]
    private string playerName;

    public string PlayerName
    {
        get => playerName;
        set => playerName = value;
    }

    public PlayerClass(float hp, float speed, float dmg) : base(hp,speed,dmg)
    {
        this.PlayerName = PhotonNetwork.LocalPlayer.NickName.ToString();
    }


    public override void TakeDmg(float newHp)
    {
        Debug.Log("Dmg taken. HP:" + gameObject.GetComponent<PlayerClass>().Hp);
        this.GetComponent<PhotonView>().RPC("TakeDmgRPC",RpcTarget.All, this.GetComponent<PhotonView>().ViewID,newHp);

    }

    [PunRPC]
    public void TakeDmgRPC(int viewID, float newHp)
    {
        Debug.Log("Rpc called. hp: " + gameObject.GetComponent<PlayerClass>().Hp);
        PhotonView.Find(viewID).gameObject.GetComponent<PlayerClass>().Hp = newHp;
        Debug.Log("HP subtracted: " + gameObject.GetComponent<PlayerClass>().Hp);
    }
}
