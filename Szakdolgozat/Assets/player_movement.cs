using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 6;
    PhotonView PV;
    PhotonRigidbodyView pvr;
    float smooth = 0.1f;
    float smoothvelocity = 1;

    //public Transform cam;
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (PV.IsMine)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 dir = new Vector3(horizontal, 0, vertical).normalized;

            if (dir.magnitude >= 0.1f)
            {
                //float targetAngle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg /*+ cam.eulerAngles.y */;
                //float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref smoothvelocity, smooth);
                //transform.rotation = Quaternion.EulerAngles(0f, angle, 0f);

                //Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
                controller.Move(dir.normalized /*moveDir.normalized*/ * speed * Time.deltaTime);
            }
            else
            {
                controller.Move(Vector3.zero.normalized * speed * Time.deltaTime);
            }


        }
    }
}
