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
            GetComponent<PhotonView>().RPC("DestroyFireball",RpcTarget.All);
            float hp = other.gameObject.GetComponent<EnemyClass>().Hp;
            float newHp = hp - 30;
            if (newHp <= 0f)
                other.gameObject.GetComponent<EnemyClass>().Die();
            else
                other.GetComponent<EnemyClass>().TakeDmg(newHp);
        }
        else if(!other.CompareTag("Player"))
        {
            GameObject explosion = PhotonNetwork.Instantiate("Explosion", this.gameObject.transform.position, Quaternion.identity);
            PhotonNetwork.Destroy(GetComponent<PhotonView>().transform.parent.gameObject);
        }
    }

    [PunRPC]
    public void DestroyFireball()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            GameObject explosion = PhotonNetwork.Instantiate("Explosion", this.gameObject.transform.position, Quaternion.identity);
            PhotonNetwork.Destroy(GetComponent<PhotonView>().transform.parent.gameObject);
           
        }
    }
}
