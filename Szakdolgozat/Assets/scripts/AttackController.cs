using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animation swordSwing;
    public Collider swordCollider;
    PhotonView PV;
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PV.IsMine)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) && !swordSwing.isPlaying)
            {
                swordSwing.Play();
                swordCollider.enabled = true;
            }

            if (!swordSwing.isPlaying)
            {
                swordCollider.enabled = false;
            }
        }
       
    }
}
