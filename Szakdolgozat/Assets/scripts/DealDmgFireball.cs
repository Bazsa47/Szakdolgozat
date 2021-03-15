using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class DealDmgFireball : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            GetComponent<PhotonView>().RPC("DestroyFireball",RpcTarget.All, GetComponent<PhotonView>().ViewID);
            float hp = other.gameObject.GetComponent<EnemyClass>().Hp;
            float newHp = hp - 30;
            if (newHp <= 0f)
                other.gameObject.GetComponent<EnemyClass>().Die();
            else
            {
                other.GetComponent<EnemyClass>().TakeDmg(newHp);

               // other.GetComponent<ChangeTarget>().GenerateThreat(gameObject.GetComponent<Projectile>().parent);
            }
 
        }
        else if(!other.CompareTag("Player"))
        {
            GameObject explosion = PhotonNetwork.Instantiate("Explosion", this.gameObject.transform.position, Quaternion.identity);
            GetComponent<PhotonView>().RPC("DestroyFireball", RpcTarget.All, GetComponent<PhotonView>().ViewID);
        }
    }

    [PunRPC]
    public void DestroyFireball(int viewId)
    {
        if (PhotonView.Find(viewId).IsMine)
        {
            GameObject explosion = PhotonNetwork.Instantiate("Explosion", this.gameObject.transform.position, Quaternion.identity);
            PhotonNetwork.Destroy(PhotonView.Find(viewId).transform.parent.gameObject);          
        }
    }
}
