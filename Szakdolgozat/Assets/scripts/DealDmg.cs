﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDmg : MonoBehaviour
{
    public PlayerClass playerClass;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            float hp = other.gameObject.GetComponent<EnemyClass>().Hp;
            float newHp = hp - playerClass.Dmg;
            if (newHp <= 0f)
                other.gameObject.GetComponent<EnemyClass>().Die();
            else
                other.GetComponent<EnemyClass>().TakeDmg(newHp);
        }
    }
}