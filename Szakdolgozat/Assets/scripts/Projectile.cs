using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody fireball;
    void Awake()
    {
        fireball = GetComponent<Rigidbody>();
    }
    void Update()
    {
        fireball.velocity = transform.forward * 10;
    }
}
