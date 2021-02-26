using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDMGEnemy : MonoBehaviour
{
    float dmg = 50;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            float hp = other.gameObject.GetComponent<PlayerClass>().Hp;
            float newHp = hp - dmg;
           
            if (newHp <= 0f)
            {                
                other.gameObject.GetComponent<PlayerClass>().Die();
            }
            else
                other.gameObject.GetComponent<PlayerClass>().TakeDmg(newHp);

        }

    }
}
