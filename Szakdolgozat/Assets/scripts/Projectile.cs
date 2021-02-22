using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IPunOwnershipCallbacks
{
    Rigidbody fireball;
    public float countdown = 3;
    bool exploded = false;
    public PhotonView PV;
    void Awake()
    {
        fireball = GetComponent<Rigidbody>();
    }
    void Update()
    {
        fireball.velocity = transform.forward * 10;
        countdown -= Time.deltaTime;

        if (countdown <= 0 && !exploded)
        {
            PV.RPC("DestroyFireball",RpcTarget.All,PV.ViewID);
            exploded = true;
        }
    }

    [PunRPC]
    void DestroyFireball(int viewId)
    {
        if (PV.IsMine)
        {
            Explode();
            PhotonNetwork.Destroy(PhotonView.Find(viewId).gameObject.transform.parent.gameObject);
        }
        else
        {
            PV.RequestOwnership();
        }
    }

    public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
    {       
    }

    public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
    {
        Explode();
        PhotonNetwork.Destroy(PhotonView.Find(PV.ViewID).gameObject.transform.parent.gameObject);
    }

    void Explode()
    {
        var explosion = PhotonNetwork.Instantiate("Explosion",this.gameObject.transform.position,Quaternion.identity);
        //PhotonNetwork.Destroy(explosion.gameObject);
    }



}
