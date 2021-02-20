using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance;
    public Animation swordSwing;
    void Start()
    {
       // target = GetComponent<EnemyClass>().Target; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(this.transform.position,target.position) <= distance)
        {
            //turn to target
            transform.rotation = new Quaternion(transform.rotation.x, -target.rotation.y,transform.rotation.z,1);

            //attack
            if (!swordSwing.isPlaying)
            {
                swordSwing.Play();
            }
        }
    }
}
