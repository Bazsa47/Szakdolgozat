using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dmgTakeTest : MonoBehaviour
{
    float dmg = 50;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision Occured. hp: " + other.GetComponent<PlayerClass>().Hp);
            float hp = other.gameObject.GetComponent<PlayerClass>().Hp;
            float newHp = hp - dmg;
            if(newHp <= 0f)
            {
                other.gameObject.GetComponent<PlayerClass>().Die();
            }
            Debug.Log("new Hp : " + newHp);
            other.gameObject.GetComponent<PlayerClass>().TakeDmg(newHp);

        }

    }
}
