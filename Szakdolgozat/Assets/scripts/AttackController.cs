using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Animation[] anim;
    public Collider[] weaponCollider;
    public PhotonView PV;
    public Transform player;

    private int currentWeaponIndex = 0;
    public GameObject sword, spear, ranged;
    private void Update()
    {
        //switch weapon
        Debug.Log(currentWeaponIndex);
        if (Input.GetKeyDown(KeyCode.Q) && !anim[currentWeaponIndex].isPlaying)
        {
            currentWeaponIndex += 1; //ezt kell elküldeni a többi playernek
            if (currentWeaponIndex > 2)
            {
                currentWeaponIndex = 0;
            }


            switch ((Weapons)(currentWeaponIndex))
            {
                case Weapons.Sword:
                    sword.SetActive(true);
                    spear.SetActive(false);
                    ranged.SetActive(false);
                    break;
                case Weapons.Spear:
                    sword.SetActive(false);
                    spear.SetActive(true);
                    ranged.SetActive(false);
                    break;
                case Weapons.Ranged:
                    sword.SetActive(false);
                    spear.SetActive(false);
                    ranged.SetActive(true);
                    break;
                default:
                    break;
            }
        }

        //basic attack
        if (Input.GetKeyDown(KeyCode.Mouse0) && !anim[currentWeaponIndex].isPlaying){
            anim[currentWeaponIndex].Play();
            if(currentWeaponIndex != 2)
                weaponCollider[currentWeaponIndex].enabled = true;
            else
            {
                PhotonNetwork.Instantiate("fireball",player.position, this.transform.rotation);
            }
        }

        if (!anim[currentWeaponIndex].isPlaying){
            if (currentWeaponIndex != 2)
                weaponCollider[currentWeaponIndex].enabled = false;
        }
    }
    public enum Weapons { Sword = 0, Spear = 1, Ranged = 2 };
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    void SwitchWeapon(int weaponID)
    {

    }

}
