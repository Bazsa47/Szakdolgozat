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

    [SerializeField]
    private bool canTakeDmg = true;
    [SerializeField]
    private float countdown = 3f;
    public override void TakeDmg(float newHp)
    {
        Debug.Log("Dmg taken. HP:" + gameObject.GetComponent<PlayerClass>().Hp);
        this.GetComponent<PhotonView>().RPC("TakeDmgRPC", RpcTarget.All, this.GetComponent<PhotonView>().ViewID, newHp);          

    }

    private void Update()
    {
        if (canTakeDmg == false)
        {
            Debug.Log("asd");
            countdown -= Time.deltaTime;
            if (countdown <= 0f)
            {
                canTakeDmg = true;
                countdown = 3f;
            }
        }
    }

    [PunRPC]
    public void TakeDmgRPC(int viewID, float newHp)
    {
        if (canTakeDmg == true)
        {
            canTakeDmg = false;
            Debug.Log("Rpc called. hp: " + gameObject.GetComponent<PlayerClass>().Hp);
            PhotonView.Find(viewID).gameObject.GetComponent<PlayerClass>().Hp = newHp;
            Debug.Log("HP subtracted: " + gameObject.GetComponent<PlayerClass>().Hp);
        }
    }
}
