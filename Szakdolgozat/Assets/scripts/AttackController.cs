using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animation[] anim;
    public Collider[] weaponCollider;
    public PhotonView PV;

    private int currentWeaponIndex = 0;
    public GameObject sword, spear;
    private void FixedUpdate()
    {
        //switch weapon
        Debug.Log(currentWeaponIndex);
        if (Input.GetKeyDown(KeyCode.Q) && !anim[currentWeaponIndex].isPlaying)
        {
            currentWeaponIndex += 1;
            if (currentWeaponIndex > 1)
            {
                currentWeaponIndex = 0;
            }


            switch ((Weapons)(currentWeaponIndex))
            {
                case Weapons.Sword:
                    sword.SetActive(true);
                    spear.SetActive(false);
                    //ranged.SetActive(false);
                    break;
                case Weapons.Spear:
                    sword.SetActive(false);
                    spear.SetActive(true);
                    //ranged.SetActive(false);
                    break;
                case Weapons.Ranged:
                    sword.SetActive(false);
                    spear.SetActive(false);
                    //ranged.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        //basic attack
        Debug.Log(currentWeaponIndex);
        if (Input.GetKeyDown(KeyCode.Mouse0) && !anim[currentWeaponIndex].isPlaying)
            {
                anim[currentWeaponIndex].Play();
                weaponCollider[currentWeaponIndex].enabled = true;
            }
            if (!anim[currentWeaponIndex].isPlaying)
            {
                weaponCollider[currentWeaponIndex].enabled = false;
            }
    }
    public enum Weapons { Sword = 0, Spear = 1, Ranged = 2 };
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

}
