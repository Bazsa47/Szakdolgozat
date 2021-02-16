using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public CharacterController controller;
    public PlayerClass playerClass;
    PhotonView PV;
    public float smooth = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    void Start()
    {
        PV = GetComponent<PhotonView>();
        cam = this.gameObject.transform.Find("Camera").GetComponent<Camera>().transform;
    }

    void Update()
    {
        if (PV.IsMine)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smooth);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * playerClass.Speed * Time.deltaTime);
            }

            //gameObject.transform.rotation = new Quaternion(gameObject.transform.rotation.x,cam.transform.rotation.y, gameObject.transform.rotation.z,1);
            
        }
    }
}
