using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClass : Entity
{
    [SerializeField]
    private Transform target;
    public Transform Target {
        get => target;
        set => target = value;
    }
    public override void Die()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDmg(float newHp)
    {
        this.GetComponent<PhotonView>().RPC("TakeDmgRPC", RpcTarget.All, this.GetComponent<PhotonView>().ViewID, newHp);
    }

    [PunRPC]
    public void TakeDmgRPC(int viewID, float newHp)
    {
        PhotonView.Find(viewID).gameObject.GetComponent<EnemyClass>().Hp = newHp;
    }
}
