using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemySlain : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
