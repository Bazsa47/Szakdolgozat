using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmgFireball : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            float hp = other.gameObject.GetComponent<EnemyClass>().Hp;
            float newHp = hp - 30;
            other.GetComponent<EnemyClass>().TakeDmg(newHp);
        }
    }
}
