using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemySlain : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            Destroy(this.gameObject);
        }
    }
}
